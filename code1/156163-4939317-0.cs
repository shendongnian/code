        #region public static byte[] ConvertAsciiToEbcdic(byte[] asciiData)
        public static byte[] ConvertAsciiToEbcdic(byte[] asciiData)     
        {          
            // Create two different encodings.         
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037");          
            
            //Retutn Ebcdic Data
            return Encoding.Convert(ascii, ebcdic, asciiData);      
        }     
        #endregion      
        
        #region public static byte[] ConvertEbcdicToAscii(byte[] ebcdicData)
        public static byte[] ConvertEbcdicToAscii(byte[] ebcdicData)
        {         
            // Create two different encodings.      
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037"); 
            
            //Retutn Ascii Data 
            return Encoding.Convert(ebcdic, ascii, ebcdicData); 
        } 
        #endregion
