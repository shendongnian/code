        //fileName = @"...\B.exe"; //The full path of the file you want to load
        public string GetAssemblyProductName(string fileName)
        {
            Assembly fileAssembly = null;
            try
            {
                fileAssembly = Assembly.LoadFile(fileName);//Loading Assembly from a file
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.Message);
                return string.Empty;
            }
            if (fileAssembly != null)
            {
                string productName = fileAssembly.GetName().Name;//This is for getting Product Name
                //string productName = fileAssembly.GetName().FullName;//This is for getting Full Name
                return productName;
            }
            else 
            {
                Console.WriteLine("Error: Not valid assembly.");
                return string.Empty;
            }
        }
