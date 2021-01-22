    Public Module Sun
    ' Get sunrise time at latitude, longitude using local system timezone
    Function Sunrises(latitude As Double, longitude As Double) As DateTime
        Dim julian As Double = JulianDay(DateTime.Now)
        Dim rises As Double = SunRiseUTC(julian, latitude, longitude)
        Dim timehere As DateTime = DateTime.Now
        Dim local As TimeZoneInfo = TimeZoneInfo.Local
        Dim dst As Boolean = local.IsDaylightSavingTime(timehere)
        Dim zone As Integer = local.BaseUtcOffset().TotalHours
        Dim result As DateTime = getDateTime(rises, zone, timehere, dst)
        Return result
    End Function
    ' Get sunset time at latitude, longitude using local system timezone
    Function Sunsets(latitude As Double, longitude As Double) As DateTime
        Dim julian As Double = JulianDay(DateTime.Now)
        Dim rises As Double = SunSetUTC(julian, latitude, longitude)
        Dim timehere As DateTime = DateTime.Now
        Dim local As TimeZoneInfo = TimeZoneInfo.Local
        Dim dst As Boolean = local.IsDaylightSavingTime(timehere)
        Dim zone As Integer = local.BaseUtcOffset().TotalHours
        Dim result As DateTime = getDateTime(rises, zone, timehere, dst)
        Return result
    End Function
    ' Convert radian angle to degrees
    Public Function Degrees(angleRad As Double) As Double
        Return (180.0 * angleRad / Math.PI)
    End Function
    ' Convert degree angle to radians
    Public Function Radians(angleDeg As Double) As Double
        Return (Math.PI * angleDeg / 180.0)
    End Function
    '* Name: JulianDay	
    '* Type: Function	
    '* Purpose: Julian day from calendar day	
    '* Arguments:	
    '* year : 4 digit year	
    '* month: January = 1	
    '* day : 1 - 31	
    '* Return value:	
    '* The Julian day corresponding to the date	
    '* Note:	
    '* Number is returned for start of day. Fractional days should be	
    '* added later.	
    Public Function JulianDay(year As Integer, month As Integer, day As Integer) As Double
        If month <= 2 Then
            year -= 1
            month += 12
        End If
        Dim A As Double = Math.Floor(year / 100.0)
        Dim B As Double = 2 - A + Math.Floor(A / 4)
        Dim julian As Double = Math.Floor(365.25 * (year + 4716)) + Math.Floor(30.6001 * (month + 1)) + day + B - 1524.5
        Return julian
    End Function
    Public Function JulianDay([date] As DateTime) As Double
        Return JulianDay([date].Year, [date].Month, [date].Day)
    End Function
    '***********************************************************************/
    '* Name: JulianCenturies	
    '* Type: Function	
    '* Purpose: convert Julian Day to centuries since J2000.0.	
    '* Arguments:	
    '* julian : the Julian Day to convert	
    '* Return value:	
    '* the T value corresponding to the Julian Day	
    '***********************************************************************/
    Public Function JulianCenturies(julian As Double) As Double
        Dim T As Double = (julian - 2451545.0) / 36525.0
        Return T
    End Function
    '***********************************************************************/
    '* Name: JulianDayFromJulianCentury	
    '* Type: Function	
    '* Purpose: convert centuries since J2000.0 to Julian Day.	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* the Julian Day corresponding to the t value	
    '***********************************************************************/
    Public Function JulianDayFromJulianCentury(t As Double) As Double
        Dim julian As Double = t * 36525.0 + 2451545.0
        Return julian
    End Function
    '***********************************************************************/
    '* Name: calGeomMeanLongSun	
    '* Type: Function	
    '* Purpose: calculate the Geometric Mean Longitude of the Sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* the Geometric Mean Longitude of the Sun in degrees	
    '***********************************************************************/
    Public Function GemoetricMeanLongitude(t As Double) As Double
        Dim L0 As Double = 280.46646 + t * (36000.76983 + 0.0003032 * t)
        While L0 > 360.0
            L0 -= 360.0
        End While
        While L0 < 0.0
            L0 += 360.0
        End While
        Return L0
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: calGeomAnomalySun	
    '* Type: Function	
    '* Purpose: calculate the Geometric Mean Anomaly of the Sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* the Geometric Mean Anomaly of the Sun in degrees	
    '***********************************************************************/
    Public Function GemoetricMeanAnomaly(t As Double) As Double
        Dim M As Double = 357.52911 + t * (35999.05029 - 0.0001537 * t)
        Return M
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: EarthOrbitEccentricity	
    '* Type: Function	
    '* Purpose: calculate the eccentricity of earth's orbit	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* the unitless eccentricity	
    '***********************************************************************/
    Public Function EarthOrbitEccentricity(t As Double) As Double
        Dim e As Double = 0.016708634 - t * (0.000042037 + 0.0000001267 * t)
        Return e
        ' unitless
    End Function
    '***********************************************************************/
    '* Name: SunCentre	
    '* Type: Function	
    '* Purpose: calculate the equation of center for the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* in degrees	
    '***********************************************************************/
    Public Function SunCentre(t As Double) As Double
        Dim m As Double = GemoetricMeanAnomaly(t)
        Dim mrad As Double = Radians(m)
        Dim sinm As Double = Math.Sin(mrad)
        Dim sin2m As Double = Math.Sin(mrad + mrad)
        Dim sin3m As Double = Math.Sin(mrad + mrad + mrad)
        Dim C As Double = sinm * (1.914602 - t * (0.004817 + 0.000014 * t)) + sin2m * (0.019993 - 0.000101 * t) + sin3m * 0.000289
        Return C
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: SunTrueLongitude	
    '* Type: Function	
    '* Purpose: calculate the true longitude of the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun's true longitude in degrees	
    '***********************************************************************/
    Public Function SunTrueLongitude(t As Double) As Double
        Dim l0 As Double = GemoetricMeanLongitude(t)
        Dim c As Double = SunCentre(t)
        Dim O As Double = l0 + c
        Return O
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: SunTrueAnomaly	
    '* Type: Function	
    '* Purpose: calculate the true anamoly of the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun's true anamoly in degrees	
    '***********************************************************************/
    Public Function SunTrueAnomaly(t As Double) As Double
        Dim m As Double = GemoetricMeanAnomaly(t)
        Dim c As Double = SunCentre(t)
        Dim v As Double = m + c
        Return v
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: SunDistanceAU	
    '* Type: Function	
    '* Purpose: calculate the distance to the sun in AU	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun radius vector in AUs	
    '***********************************************************************/
    Public Function SunDistanceAU(t As Double) As Double
        Dim v As Double = SunTrueAnomaly(t)
        Dim e As Double = EarthOrbitEccentricity(t)
        Dim R As Double = (1.000001018 * (1 - e * e)) / (1 + e * Math.Cos(Radians(v)))
        Return R
        ' in AUs
    End Function
    '***********************************************************************/
    '* Name: SunApparentLongitude	
    '* Type: Function	
    '* Purpose: calculate the apparent longitude of the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun's apparent longitude in degrees	
    '***********************************************************************/
    Public Function SunApparentLongitude(t As Double) As Double
        Dim o As Double = SunTrueLongitude(t)
        Dim omega As Double = 125.04 - 1934.136 * t
        Dim lambda As Double = o - 0.00569 - 0.00478 * Math.Sin(Radians(omega))
        Return lambda
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: MeanObliquityOfEcliptic	
    '* Type: Function	
    '* Purpose: calculate the mean obliquity of the ecliptic	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* mean obliquity in degrees	
    '***********************************************************************/
    Public Function MeanObliquityOfEcliptic(t As Double) As Double
        Dim seconds As Double = 21.448 - t * (46.815 + t * (0.00059 - t * (0.001813)))
        Dim e0 As Double = 23.0 + (26.0 + (seconds / 60.0)) / 60.0
        Return e0
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: calcObliquityCorrection	
    '* Type: Function	
    '* Purpose: calculate the corrected obliquity of the ecliptic	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* corrected obliquity in degrees	
    '***********************************************************************/
    Public Function calcObliquityCorrection(t As Double) As Double
        Dim e0 As Double = MeanObliquityOfEcliptic(t)
        Dim omega As Double = 125.04 - 1934.136 * t
        Dim e As Double = e0 + 0.00256 * Math.Cos(Radians(omega))
        Return e
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: SunRightAscension	
    '* Type: Function	
    '* Purpose: calculate the right ascension of the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun's right ascension in degrees	
    '***********************************************************************/
    Public Function SunRightAscension(t As Double) As Double
        Dim e As Double = calcObliquityCorrection(t)
        Dim lambda As Double = SunApparentLongitude(t)
        Dim tananum As Double = (Math.Cos(Radians(e)) * Math.Sin(Radians(lambda)))
        Dim tanadenom As Double = (Math.Cos(Radians(lambda)))
        Dim alpha As Double = Degrees(Math.Atan2(tananum, tanadenom))
        Return alpha
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: SunDeclination	
    '* Type: Function	
    '* Purpose: calculate the declination of the sun	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* sun's declination in degrees	
    '***********************************************************************/
    Public Function SunDeclination(t As Double) As Double
        Dim e As Double = calcObliquityCorrection(t)
        Dim lambda As Double = SunApparentLongitude(t)
        Dim sint As Double = Math.Sin(Radians(e)) * Math.Sin(Radians(lambda))
        Dim theta As Double = Degrees(Math.Asin(sint))
        Return theta
        ' in degrees
    End Function
    '***********************************************************************/
    '* Name: TrueSolarToMeanSolar	
    '* Type: Function	
    '* Purpose: calculate the difference between true solar time and mean	
    '*	 solar time	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* Return value:	
    '* equation of time in minutes of time	
    '***********************************************************************/
    Public Function TrueSolarToMeanSolar(t As Double) As Double
        Dim epsilon As Double = calcObliquityCorrection(t)
        Dim l0 As Double = GemoetricMeanLongitude(t)
        Dim e As Double = EarthOrbitEccentricity(t)
        Dim m As Double = GemoetricMeanAnomaly(t)
        Dim y As Double = Math.Tan(Radians(epsilon) / 2.0)
        y *= y
        Dim sin2l0 As Double = Math.Sin(2.0 * Radians(l0))
        Dim sinm As Double = Math.Sin(Radians(m))
        Dim cos2l0 As Double = Math.Cos(2.0 * Radians(l0))
        Dim sin4l0 As Double = Math.Sin(4.0 * Radians(l0))
        Dim sin2m As Double = Math.Sin(2.0 * Radians(m))
        Dim Etime As Double = y * sin2l0 - 2.0 * e * sinm + 4.0 * e * y * sinm * cos2l0 - 0.5 * y * y * sin4l0 - 1.25 * e * e * sin2m
        Return Degrees(Etime) * 4.0
        ' in minutes of time
    End Function
    '***********************************************************************/
    '* Name: SunriseHourAngle	
    '* Type: Function	
    '* Purpose: calculate the hour angle of the sun at sunrise for the	
    '*	 latitude	
    '* Arguments:	
    '* lat : latitude of observer in degrees	
    '*	solarDec : declination angle of sun in degrees	
    '* Return value:	
    '* hour angle of sunrise in radians	
    '***********************************************************************/
    Public Function SunriseHourAngle(lat As Double, solarDec As Double) As Double
        Dim latRad As Double = Radians(lat)
        Dim sdRad As Double = Radians(solarDec)
        Dim HAarg As Double = (Math.Cos(Radians(90.833)) / (Math.Cos(latRad) * Math.Cos(sdRad)) - Math.Tan(latRad) * Math.Tan(sdRad))
        Dim HA As Double = (Math.Acos(Math.Cos(Radians(90.833)) / (Math.Cos(latRad) * Math.Cos(sdRad)) - Math.Tan(latRad) * Math.Tan(sdRad)))
        Return HA
        ' in radians
    End Function
    '***********************************************************************/
    '* Name: SunsetHourAngle	
    '* Type: Function	
    '* Purpose: calculate the hour angle of the sun at sunset for the	
    '*	 latitude	
    '* Arguments:	
    '* lat : latitude of observer in degrees	
    '*	solarDec : declination angle of sun in degrees	
    '* Return value:	
    '* hour angle of sunset in radians	
    '***********************************************************************/
    Public Function SunsetHourAngle(lat As Double, solarDec As Double) As Double
        Dim latRad As Double = Radians(lat)
        Dim sdRad As Double = Radians(solarDec)
        Dim HAarg As Double = (Math.Cos(Radians(90.833)) / (Math.Cos(latRad) * Math.Cos(sdRad)) - Math.Tan(latRad) * Math.Tan(sdRad))
        Dim HA As Double = (Math.Acos(Math.Cos(Radians(90.833)) / (Math.Cos(latRad) * Math.Cos(sdRad)) - Math.Tan(latRad) * Math.Tan(sdRad)))
        Return -HA
        ' in radians
    End Function
    '***********************************************************************/
    '* Name: SunRiseUTC	
    '* Type: Function	
    '* Purpose: calculate the Universal Coordinated Time (UTC) of sunrise	
    '*	 for the given day at the given location on earth	
    '* Arguments:	
    '* julian : julian day	
    '* latitude : latitude of observer in degrees	
    '* longitude : longitude of observer in degrees	
    '* Return value:	
    '* time in minutes from zero Z	
    '***********************************************************************/
    'Public  Function SunRiseUTC(julian As Double, latitude As Double, longitude As Double) As Double
    '    Dim t As Double = JulianCenturies(julian)
    '    ' *** Find the time of solar noon at the location, and use
    '    ' that declination. This is better than start of the 
    '    ' Julian day
    '    Dim noonmin As Double = SolarNoonUTC(t, longitude)
    '    Dim tnoon As Double = JulianCenturies(julian + noonmin / 1440.0)
    '    ' *** First pass to approximate sunrise (using solar noon)
    '    Dim eqTime As Double = TrueSolarToMeanSolar(tnoon)
    '    Dim solarDec As Double = SunDeclination(tnoon)
    '    Dim hourAngle As Double = SunriseHourAngle(latitude, solarDec)
    '    Dim delta As Double = longitude - Degrees(hourAngle)
    '    Dim timeDiff As Double = 4 * delta
    '    ' in minutes of time
    '    Dim timeUTC As Double = 720 + timeDiff - eqTime
    '    ' in minutes
    '    ' alert("eqTime = " + eqTime + "\nsolarDec = " + solarDec + "\ntimeUTC = " + timeUTC);
    '    ' *** Second pass includes fractional julianay in gamma calc
    '    Dim newt As Double = JulianCenturies(JulianDayFromJulianCentury(t) + timeUTC / 1440.0)
    '    eqTime = TrueSolarToMeanSolar(newt)
    '    solarDec = SunDeclination(newt)
    '    hourAngle = SunriseHourAngle(latitude, solarDec)
    '    delta = longitude - Degrees(hourAngle)
    '    timeDiff = 4 * delta
    '    timeUTC = 720 + timeDiff - eqTime
    '    ' in minutes
    '    ' alert("eqTime = " + eqTime + "\nsolarDec = " + solarDec + "\ntimeUTC = " + timeUTC);
    '    Return timeUTC
    'End Function
    '***********************************************************************/
    '* Name: SolarNoonUTC	
    '* Type: Function	
    '* Purpose: calculate the Universal Coordinated Time (UTC) of solar	
    '*	 noon for the given day at the given location on earth	
    '* Arguments:	
    '* t : number of Julian centuries since J2000.0	
    '* longitude : longitude of observer in degrees	
    '* Return value:	
    '* time in minutes from zero Z	
    '***********************************************************************/
    Public Function SolarNoonUTC(t As Double, longitude As Double) As Double
        ' First pass uses approximate solar noon to calculate eqtime
        Dim tnoon As Double = JulianCenturies(JulianDayFromJulianCentury(t) + longitude / 360.0)
        Dim eqTime As Double = TrueSolarToMeanSolar(tnoon)
        Dim solNoonUTC As Double = 720 + (longitude * 4) - eqTime
        ' min
        Dim newt As Double = JulianCenturies(JulianDayFromJulianCentury(t) - 0.5 + solNoonUTC / 1440.0)
        eqTime = TrueSolarToMeanSolar(newt)
        ' double solarNoonDec = SunDeclination(newt);
        solNoonUTC = 720 + (longitude * 4) - eqTime
        ' min
        Return solNoonUTC
    End Function
    '***********************************************************************/
    '* Name: SunSetUTC	
    '* Type: Function	
    '* Purpose: calculate the Universal Coordinated Time (UTC) of sunset	
    '*	 for the given day at the given location on earth	
    '* Arguments:	
    '* julian : julian day	
    '* latitude : latitude of observer in degrees	
    '* longitude : longitude of observer in degrees	
    '* Return value:	
    '* time in minutes from zero Z	
    '***********************************************************************/
    Public Function SunSetUTC(julian As Double, latitude As Double, longitude As Double) As Double
        Dim t = JulianCenturies(julian)
        Dim eqTime = TrueSolarToMeanSolar(t)
        Dim solarDec = SunDeclination(t)
        Dim hourAngle = SunriseHourAngle(latitude, solarDec)
        hourAngle = -hourAngle
        Dim delta = longitude + Degrees(hourAngle)
        Dim timeUTC = 720 - (4.0 * delta) - eqTime
        ' in minutes
        Return timeUTC
    End Function
    Public Function SunRiseUTC(julian As Double, latitude As Double, longitude As Double) As Double
        Dim t = JulianCenturies(julian)
        Dim eqTime = TrueSolarToMeanSolar(t)
        Dim solarDec = SunDeclination(t)
        Dim hourAngle = SunriseHourAngle(latitude, solarDec)
        Dim delta = longitude + Degrees(hourAngle)
        Dim timeUTC = 720 - (4.0 * delta) - eqTime
        ' in minutes
        Return timeUTC
    End Function
    Public Function getTimeString(time As Double, timezone As Integer, julian As Double, dst As Boolean) As String
        Dim timeLocal = time + (timezone * 60.0)
        Dim riseT = JulianCenturies(julian + time / 1440.0)
        timeLocal += (If((dst), 60.0, 0.0))
        Return getTimeString(timeLocal)
    End Function
    Public Function getDateTime(time As Double, timezone As Integer, [date] As DateTime, dst As Boolean) As System.Nullable(Of DateTime)
        Dim julian As Double = JulianDay([date])
        Dim timeLocal = time + (timezone * 60.0)
        Dim riseT = JulianCenturies(julian + time / 1440.0)
        timeLocal += (If((dst), 60.0, 0.0))
        Return getDateTime(timeLocal, [date])
    End Function
    Private Function getTimeString(minutes As Double) As String
        Dim output As String = ""
        If (minutes >= 0) AndAlso (minutes < 1440) Then
            Dim floatHour = minutes / 60.0
            Dim hour = Math.Floor(floatHour)
            Dim floatMinute = 60.0 * (floatHour - Math.Floor(floatHour))
            Dim minute = Math.Floor(floatMinute)
            Dim floatSec = 60.0 * (floatMinute - Math.Floor(floatMinute))
            Dim second = Math.Floor(floatSec + 0.5)
            If second > 59 Then
                second = 0
                minute += 1
            End If
            If (second >= 30) Then
                minute += 1
            End If
            If minute > 59 Then
                minute = 0
                hour += 1
            End If
            output = [String].Format("{0:00}:{1:00}", hour, minute)
        Else
            Return "error"
        End If
        Return output
    End Function
    Private Function getDateTime(minutes As Double, [date] As DateTime) As System.Nullable(Of DateTime)
        Dim retVal As System.Nullable(Of DateTime) = Nothing
        If (minutes >= 0) AndAlso (minutes < 1440) Then
            Dim floatHour = minutes / 60.0
            Dim hour = Math.Floor(floatHour)
            Dim floatMinute = 60.0 * (floatHour - Math.Floor(floatHour))
            Dim minute = Math.Floor(floatMinute)
            Dim floatSec = 60.0 * (floatMinute - Math.Floor(floatMinute))
            Dim second = Math.Floor(floatSec + 0.5)
            If second > 59 Then
                second = 0
                minute += 1
            End If
            If (second >= 30) Then
                minute += 1
            End If
            If minute > 59 Then
                minute = 0
                hour += 1
            End If
            Return New DateTime([date].Year, [date].Month, [date].Day, CInt(hour), CInt(minute), CInt(second))
        Else
            Return retVal
        End If
    End Function
    End Module
