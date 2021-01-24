            string[] Params = { "SELECT", "FROM", "WHERE", "AND", "OR", "ORDER BY" };
            Dictionary<string, string> sqlSource = new Dictionary<string, string>();
            string sqlString = "SELECT poc, event, network, vendor FROM bLine WHERE network = 'something'";
            int i, j;
            //iterate through all the items from Params array
            for (i = 0; i < Params.Length; i++)
            {
                string result = "";
                //take next element from Params array for SELECT next will be FROM
                for (j = i + 1; j < Params.Length; j++)
                {
                    int ab = sqlString.IndexOf(Params[j]);
                    //Get the substring between SELECT and FROM
                    if (ab > 0)
                    {
                        int pFrom = sqlString.IndexOf(Params[i]) + Params[i].Length;
                        int pTo = sqlString.LastIndexOf(Params[j]);
                        result = sqlString.Substring(pFrom, (pTo - pFrom));
                    }
                    //if there is a string then break the loop  
                    if (result != "")
                    {
                        sqlSource.Add(Params[i], result);
                        break;
                    }
                }
                //if result is empty which is possible after FROM clause if there are no WHERE/AND/OR/ORDER BY then get substring between FROM and end of string
                if (result == "")
                {
                    int pFrom = sqlString.IndexOf(Params[i]) + Params[i].Length;
                    int pTo = sqlString.Length;
                    result = sqlString.Substring(pFrom, (pTo - pFrom));
                    sqlSource.Add(Params[i], result);
                    break;
                }
            }
