//UTF8
        public static string ConvertToUTF8(string inputString)
        {
            string toReturn = "";
            byte[] arr = Encoding.UTF8.GetBytes(inputString);
            for (int i = 0; i &lt arr.Length; i++)
            {
                toReturn += arr[i].ToString() + " ";
            }
            return toReturn;
        }
        public static string ConvertFromUTF8(string inputString)
        {
            inputString = inputString.Trim();
            string result = "";
            string[] parts = inputString.Split(' ');
            byte[] bytes = new byte[parts.Length];
            for (int i = 0; i &lt parts.Length; i++)
            {
                if (parts[i] == "")
                {
                    continue;
                }
                try
                {
                    bytes[i] = Convert.ToByte(parts[i]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Input string was not in a correct format.");
                }
            }
            try
            {
                result = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
