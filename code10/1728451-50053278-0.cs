    using System;
    using System.Collections.Generic;
    namespace Test_DeleteLater
    {
        public class WeirdLineFormatReader
        {
            public IEnumerable<Tuple<string, string>> ReadLines(string[] lines)
            {
                foreach (string line in lines)
                {
                    // split each line on the =
                    string[] strLineArray = line.Split('=');
                    
                    // get the first and second values of the split line
                    string field = strLineArray[0];
                    string value = strLineArray[1];
                    // remove the first field word
                    field = field.Substring("field".Length);
                    // remove the .name portion
                    field = field.Replace(".name", "");
                    // remove the surrounding white-space
                    field = field.Trim();
                    // remove all white space before/after the description
                    value = value.Trim();
                    yield return new Tuple<string, string>(field, value);
                }
            }
        }
    }
