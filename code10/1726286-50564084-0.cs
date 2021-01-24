    // Longitude: Build a whole property value
    byte[] propertyTagGpsLongitude = new byte[24];
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeDegreeNumerator), 0, propertyTagGpsLongitude, 0, 4);
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeDegreeDenominator), 0, propertyTagGpsLongitude, 4, 4);
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeMinuteNumerator), 0, propertyTagGpsLongitude, 8, 4);
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeMinuteDenominator), 0, propertyTagGpsLongitude, 12, 4);
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeSecondNumerator), 0, propertyTagGpsLongitude, 16, 4);
    Buffer.BlockCopy(BitConverter.GetBytes(LongitudeSecondDenominator), 0, propertyTagGpsLongitude, 20, 4);
