        public static bool isValidAssembly (string sFileName)
        {
            try
            {
                using (FileStream fs = File.OpenRead(sFileName))
                {
                    if ((fs.ReadByte() != 'M') || (fs.ReadByte() != 'Z'))
                    {
                        fs.Close();
                        return false;
                    }
                    fs.Close();
                }
                // http://msdn.microsoft.com/en-us/library/ms173100.aspx
                object foo = SR.AssemblyName.GetAssemblyName(sFileName);
                return true;
            }
            catch 
            {
                return false;
            }
        }
