        MemoryStream _memoryStream = new MemoryStream();
        public bool Converto(Stream stream)
        {
            try
            {
                copyStream(stream);
                //more code
            }
            catch (IOException ex)
            {
              //  Debug.WriteLine(ex);
            }
            return true;
        }
        private void copyStream(Stream stream)
        {
            try
            {
                stream.CopyTo(_memoryStream); 
            }
            catch (Exception)
            {
              
            }
            
        }
