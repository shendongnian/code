            string[,] data = new string[dt.Rows.Count, dt.Columns.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                int j = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    data[i,j++] = row[col].ToString();
                }
                i++;
            }
            
            //dump the whole array to the range
            x.Value = data
