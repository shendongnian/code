            List<SqlParameter> sqlParams = new List<SqlParameter>();//
            DataTable dt = DAL.ExecStoredProcedure("spMsgSearch", sqlParams);//run dal , get a dt back
            //DataSet dr = DalDataSet.ExecStoredProc("spMsgSearch", sqlParams);
            Dictionary<string, string> dic = new Dictionary<string, string>();//create new dict
            foreach (DataRow dr1 in dt.Rows)//for each row in the datatable add a row from the entries within
            {
                string key = dr1[0].ToString() + "-" + dr1[0].ToString();
                string value = dr1[0].ToString() + "-" + dr1[0].ToString();
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, value);
                }
            }//end foreach
            dataGridView1.DataSource = dic.ToList();//the ToList solved the error
