        for (int i = 0; i < fileNamesList.Count; i++)
        {
            for (int j = 0; j < fileNamesList[i].Item3.Count(); j++)
            {
                if (String.IsNullOrEmpty(fileNamesList[i].Item3[j]))
                {
                    Console.WriteLine("Empty");
                }
                else if (!String.IsNullOrEmpty(fileNamesList[i].Item3[j]))
                {
                    if (fileNamesList[i].Item1.Equals("INCLUDE"))
                    {
                        string dataType = fileNamesList[i].Item1;
                        string date = fileNamesList[i].Item2;
                        string[] fileContent = fileNamesList[i].Item3;
                        clearList.Add(new Tuple<string, string, float[]>(dataType, date, Array.ConvertAll(fileContent, new Converter<string, float>(s => float.Parse(s, CultureInfo.InvariantCulture )))));
                    }
                }
            }
        }
