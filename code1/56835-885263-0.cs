    public static String GetString(System.IO.Stream inStream)
        {
            string str = string.Empty;
            using (StreamReader reader = new StreamReader(inStream, System.Text.ASCIIEncoding.ASCII))
            {
                str = reader.ReadToEnd();
            }
            return str;
        }
