        public static bool FileToTxt(string filepath)
        {
            try { 
            //Install-Package DocX
            string textFilePath = Path.ChangeExtension(filepath, ".txt");
            DocX docx = DocX.Load(filepath);
            File.WriteAllText(textFilePath, docx.Text);
            }catch(Exception e)
            {
                Console.WriteLine($"{Path.GetFileName(filepath)} error: {e.Message}");
                return false;
            }
            return true;
        }
