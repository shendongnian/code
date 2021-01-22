            DataTable dt = new DataTable();
            TextBox ResultTextBox;
            
            StringBuilder result = new StringBuilder();
            
            foreach(DataRow dr in dt.Rows)
            {
                foreach(DataColumn dc in dt.Columns)
                {
                    result.Append(dr[dc].ToString());
                }
            }
            
            ResultTextBox.Text = result.ToString();
