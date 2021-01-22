            string[] strArray = Array.ConvertAll<object,string>(objArray,Convert.ToString);           
            Dictionary<string, string> dictionary = null;
            try
            {
                dictionary = new Dictionary<string, string>();
                for (int iVal = 0; iVal < strArray.Length; )
                {
                    dictionary.Add(strArray[iVal], strArray[iVal + 1]);
                    iVal += 2;
                }
            }
            catch (Exception ex)
            {
            }
            return dictionary;
        }
