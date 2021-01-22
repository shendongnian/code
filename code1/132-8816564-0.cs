       Public Shared Function CalculateAge(BirthDate As DateTime) As Integer
            Dim HebCal As New System.Globalization.HebrewCalendar ()
			Dim now = DateTime.Now()
			Dim iAge = HebCal.GetYear(now) - HebCal.GetYear(BirthDate)
			Dim iNowMonth = HebCal.GetMonth(now), iBirthMonth = HebCal.GetMonth(BirthDate)
			If iNowMonth < iBirthMonth Or (iNowMonth = iBirthMonth AndAlso HebCal.GetDayOfMonth(now) < HebCal.GetDayOfMonth(BirthDate)) Then iAge -= 1
			Return iAge
		End Function
