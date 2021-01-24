    static void Main(string[] args)
        {
            var oldData = ReadOldData();
            
            // Do the work
            var results = SumValuesForSameDate(oldData);
            // Write the file
            using (System.IO.FileStream fileStream = new System.IO.FileStream(@"C: \Users\---\Csvsave\SaveDatei.csv", System.IO.FileMode.Append, System.IO.FileAccess.Write))
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fileStream))
            {
                foreach (KeyValuePair<DateTime, int[]> kvp in results)
                {
                    streamWriter.WriteLine("{0}; {1}", kvp.Key, string.Join(";", kvp.Value));
                }
            }
        }
        public static Dictionary<DateTime, int[]> SumValuesForSameDate(string[][] readData)
        {
            var oDateTimeAndIntDictionary = new Dictionary<DateTime, int[]>();
            var currentDate = DateTime.MinValue;
            foreach (var row in readData)
            {
                DateTime dateValue;
                if(!DateTime.TryParse(row[0], out dateValue)) continue;
                dateValue = dateValue.Date;
                var intValues = ConvertArrayToInt(row);
                if (dateValue == currentDate)
                {
                    for (var j = 0; j < intValues.Length; j++)
                    {
                        oDateTimeAndIntDictionary[dateValue][j] += intValues[j];
                    }
                }
                else
                {
                    oDateTimeAndIntDictionary.Add(dateValue, intValues);
                    currentDate = dateValue;
                }
            }
            return oDateTimeAndIntDictionary;
        }
        static int[] ConvertArrayToInt(string[] strings)
        {
            var output = new int[strings.Length - 1];
            for (var i = 1; i < strings.Length; i++)
            {
                output[i - 1] = int.Parse(strings[i]);
            }
            return output;
        }
        static string[][] ReadOldData()
        {
            // Fake data
            var data = new string[][]
            {
                new string[] { "20.11.2018 00:00:00", "1", "1", "1", "1", "1"  },
                new string[] { "20.11.2018 00:00:00", "1", "1", "1", "1", "1"  },
                new string[] { "22.11.2018 00:00:00", "1", "1", "1", "1", "1"  },
            };
            return data;
        }
    }
