    private double ConvertDegreesToDecimal(string coordinate)
    {
        double decimalCoordinate;
        string[] coordinateArray = coordinate.Split(':');
        if (3 == coordinateArray.Length)
        {
            double degrees = Double.Parse(coordinateArray[0]);
            double minutes = Double.Parse(coordinateArray[1]) / 60;
            double seconds = Double.Parse(coordinateArray[2]) / 3600;
            if (degrees > 0)
            {
                decimalCoordinate = (degrees + minutes + seconds);
            }
            else
            {
                decimalCoordinate = (degrees - minutes - seconds);
            }
        }
        return decimalCoordinate;
    }
