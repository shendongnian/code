        private void func()
        {
            string input = "123,a,b,3|456,c,d,5|111,acd,55,c1|,,,,|,,,,|,,,,";
            List<IEnumerable<string>> parsedLines = new List<IEnumerable<string>>();
            foreach (string line in input.Split('|')) //foreach row
                parsedLines.Add(line.Split(',')); //add that as a list of columns
            //select rows that have at least one column with text
            var result = parsedLines.Where(line => line.Any(field => !string.IsNullOrEmpty(field)));
        }
