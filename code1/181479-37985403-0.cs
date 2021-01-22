    private string ReadFileAndFetchStringInSingleLine(string file)
        {
            StringBuilder sb;
            try
            {
                sb = new StringBuilder();
                using (FileStream fs = File.Open(file, FileMode.Open))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        using (StreamReader sr = new StreamReader(bs))
                        {
                            string str;
                            while ((str = sr.ReadLine()) != null)
                            {
                                sb.Append(str);
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
