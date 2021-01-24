            DataTable dt = new DataTable();
            dt.Columns.Add("NPM");
            string NPM = "";
            string NPM_CEK = "";
            List<string> NPMList = new List<string>();
            for (int i = 0; i < grd.Rows.Count - 1; i++)
            {
                NPM = grd.Rows[i].Cells["NPM"].Value.ToString();
                
                if (!NPMList.Contains(NPM))
                {
                    DataRow row = dt.NewRow();
                    row[0] = NPM;
                    dt.Rows.Add(row);
                   
                    NPMList.Add(NPM);
                }
              
            }
            grd2.DataSource = dt;  
