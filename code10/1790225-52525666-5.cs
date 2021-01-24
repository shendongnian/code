    /// <summary>
    /// Remove zero padding by starting at the end of the data block assuming
    /// no padding, and using the check sum appended to the end of the data to
    /// verify the original data, incrementing padding until we match the 
    /// check sum or conclude data is corrupt
    /// </summary>
    /// <param name="data">Decrypted data block, including zero padding and checksum at end</param>
    /// <param name="checkSumLen">Length of the checksum appended to the end of the data</param>
    /// <returns>Unencrypted original data without padding and without check sum</returns>
    private byte[] RemovePaddingAndCheckSum(byte[] data, int checkSumLen)
    {
        byte[] checkSum = new byte[checkSumLen];
        int padding = 0;
        while ((data.Length - checkSumLen - padding) > 0)
        {
            int checkSumStart = data.Length - checkSumLen - padding;
            Buffer.BlockCopy(data, checkSumStart, checkSum, 0, checkSumLen);
            int dataLength = data.Length - checkSumLen - padding;
            byte[] dataClean = new byte[dataLength];
            Buffer.BlockCopy(data, 0 , dataClean, 0, dataLength);
            if (VerifyCheckSum(dataClean, checkSum))
                return dataClean;
            padding++;
        }
        throw new InvalidDataException("Unable to decrypt, check sum does not match");
    }
