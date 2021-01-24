        // -----------------------------------------------------------
        // Creates a Dictionary with Grouping Counts from a DataTable
        public Dictionary<string, Int32> GroupBy(DataTable myDataTable, params string[] pGroupByFieldNames)
        {
            Dictionary<string, Int32> myGroupBy = new Dictionary<string, Int32>(StringComparer.InvariantCultureIgnoreCase);  //Makes the Key Case Insensitive
            foreach (DataRow myRecord in myDataTable.Rows)
            {
                string myKey = "";
                foreach (string strGroupFieldName in pGroupByFieldNames)
                {
                    myKey += Convert.ToString(myRecord[strGroupFieldName]).Trim();
                }
                if (myGroupBy.ContainsKey(myKey) == false)
                {
                    myGroupBy.Add(myKey, 1);
                }
                else
                {
                    myGroupBy[myKey] += 1;
                }
            }
            return myGroupBy;
        }
