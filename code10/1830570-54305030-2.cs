        public static DataTable JoinDataTables2(DataTable dt1, DataTable dt2, string table1KeyField, string table2KeyField)
        {
            // Join with final selection containing rows from both the tablles
            var query = from dataRows1 in dt1.AsEnumerable()
                        join dataRows2 in dt2.AsEnumerable()
                            on dataRows1.Field<string>(table1KeyField) equals dataRows2.Field<string>(table2KeyField)
                        select new Result
                        {
                            Table1Row = dataRows1,
                            Table2Row = dataRows2,
                            DistictFieldValue = dataRows2[table2KeyField].ToString() // This could be anything else, even passed as an argument to the method
                        };
            
            // Dictinct on the results above
            var queryWithDistictResults = query.Distinct(new ResultComparer());
            // Write your logic to convert the Results Collection to a single data table with whatever columns you want
            DataTable result = queryWithDistictResults // <= YOUR LOGIC HERE
            
            return result;
        }
