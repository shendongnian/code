        private string quotedprintable(string data, string encoding)
        {
            data = data.Replace("=\r\n", "");
            for (int position = -1; (position = data.IndexOf("=", position + 1)) != -1;)
            {
                string leftpart = data.Substring(0, position);
                System.Collections.ArrayList hex = new System.Collections.ArrayList();
                hex.Add(data.Substring(1 + position, 2));
                while (position + 3 < data.Length && data.Substring(position + 3, 1) == "=")
                {
                    position = position + 3;
                    hex.Add(data.Substring(1 + position, 2));
                }
                byte[] bytes = new byte[hex.Count];
                for (int i = 0; i < hex.Count; i++)
                {
                    bytes[i] = System.Convert.ToByte(new string(((string)hex[i]).ToCharArray()), 16);
                }
                string equivalent = System.Text.Encoding.GetEncoding(encoding).GetString(bytes);
                string rightpart = data.Substring(position + 3);
                data = leftpart + equivalent + rightpart;
            }
            return data;
        }
