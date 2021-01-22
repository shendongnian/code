            Dictionary<int, int> jsonValues = new Dictionary<int, int>();
            string data = "[[\"9\",\"3\"],[\"8\",\"4\"],[\"7\",\"4\"],[\"6\",\"5\"],[\"5\",\"6\"],[\"4\",\"4\"],[\"3\",\"4\"]]";
            string[] items = data.Split(new string[]{"\"],[\""}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in items)
            {
                string[] intVals = str
                    .Replace("\"", "")
                    .Replace("[", "")
                    .Replace("[", "")
                    .Replace("]", "").Split(',');
                jsonValues.Add(int.Parse(intVals[0]), int.Parse(intVals[1]));
            }
            // test print:
            foreach (KeyValuePair<int,int> kvp in jsonValues)
            {
                System.Diagnostics.Debug.WriteLine(
                    "ID:" + kvp.Key + " val:" + kvp.Value );
            }
