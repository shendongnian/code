        private string[] csvParser(string csv, char separator = ',')
        {
            List <string> = new <string>();
            string[] temp = csv.Split(separator);
            int counter = 0;
            string data = string.Empty;
            while (counter < temp.Length)
            {
                data = temp[counter].Trim();
                if (data.Trim().StartsWith("\""))
                {
                    bool isLast = false;
                    while (!isLast && counter < temp.Length)
                    {
                        data += separator.ToString() + temp[counter + 1];
                        counter++;
                        isLast = (temp[counter].Trim().EndsWith("\""));
                    }
                }
                parsed.Add(data);
                counter++;
            }
            return parsed.ToArray();
        }
