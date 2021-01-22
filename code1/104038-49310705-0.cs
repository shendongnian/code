     public string ConvertToFourByteBinaryNumber(Int32 value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            
            Array.Reverse(intBytes); // IsLittleEndian
    
            return Encoding.Default.GetString(intBytes);
        }
    
        public string ConvertToEightByteBinaryNumber(long value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
    
            Array.Reverse(intBytes); // IsLittleEndian
    
            return Encoding.Default.GetString(intBytes);
        }
