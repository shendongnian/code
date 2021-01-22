            Sql DataAdapter sda = new SqlDataAdapter("select * from emp", con);
            Dataset ds = new DataSet();
            sda.Fill(ds, "emp_id");
            string EmpId;
            //this condition checks that table is empty
            // or not if table is empty that bill id is E0001 other wise else par is run
            if (ds.Tables[0].Rows.Count == 0)
            {
                EmpId = "E0001";
            }
            else
            {
                string s = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["emp_id"].ToString();
                //retriving empid column last cell data.
                int len = s.Length;
                string splitno = s.Substring(3, len - 3); //spliting string
                int num = Convert.ToInt32(splitno); //converting splited string in integer
                num++; //increasing splited string by 1
                EmpId = s.Substring(0, 3) + num.ToString("0000"); //adding String and store in empid string
            }
