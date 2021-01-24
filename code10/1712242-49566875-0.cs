    //This is in meters
            double iDistanceDegreeConverter = 10000.0 / 90.0 * 1000;
            double iLatOffset = iRadius / iDistanceDegreeConverter;
            double iLngOffset = iRadius / (Math.Cos(iLat) * iDistanceDegreeConverter);
            double iMaxLat = Math.Abs(iLat) + iLatOffset;
            double iMinLat = Math.Abs(iLat) - iLatOffset;
            double iMaxLng = Math.Abs(iLng) + iLngOffset;
            double iMinLng = Math.Abs(iLng) - iLngOffset;
            if (iLat < 0)
            {
                iMaxLat *= -1;
                iMinLat *= -1;
            }
            if (iLng < 0)
            {
                iMaxLng *= -1;
                iMinLng *= -1;
            }
            if (iMaxLat > 90)
            {
                double iOverflow = iMaxLat - 90;
                iMaxLat = 90 - iOverflow;
            }
            if (iMinLat < -90)
            {
                double iOverflow = -90 + iMinLat;
                iMinLat = -90 + iOverflow;
            }
            if (iMaxLng > 180)
            {
                double iOverflow = iMaxLng - 180;
                iMaxLng = 180 - iOverflow;
            }
            if (iMinLng < -180)
            {
                double iOverflow = -180 + iMinLng;
                iMinLng = -180 + iOverflow;
            }
