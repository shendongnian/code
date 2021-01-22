            AssemblyName assemblyName = null;
            try
            {
                assemblyName = AssemblyName.GetAssemblyName(filename);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new Exception("File not found!", ex);
            }
            catch (System.BadImageFormatException ex)
            {
                throw new Exception("File is not an .Net Assembly.", ex);
            }
            
