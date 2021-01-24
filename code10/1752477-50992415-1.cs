           var dt1 = new DataTable(); //your data source
            var lsts = new List<List<string>>();
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                var singleColumnLst = new List<string>();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    singleColumnLst.Add((string)dt1.Rows[i][j]);
                }
                lsts.Add(singleColumnLst);
            }
            //final results
            var allItems = CartesianProduct(lsts, "-");
