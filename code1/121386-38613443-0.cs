        using Microsoft.VisualBasic.FileIO;
        public static List<List<string>> ParseCSV (string csv)
        {
            List<List<string>> result = new List<List<string>>();
            // To use the TextFieldParser a reference to the Microsoft.VisualBasic assembly has to be added to the project. 
            using (TextFieldParser parser = new TextFieldParser(new StringReader(csv))) 
            {
                parser.CommentTokens = new string[] { "#" };
                parser.SetDelimiters(new string[] { ";" });
                parser.HasFieldsEnclosedInQuotes = true;
                // Skip over header line.
                //parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var values = new List<string>();
                    var readFields = parser.ReadFields();
                    if (readFields != null)
                        values.AddRange(readFields);
                    result.Add(values);
                }
            }
            return result;
        }
