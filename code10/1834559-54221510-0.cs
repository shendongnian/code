                DataTable dt = new DataTable();
                dt.Columns.Add("UserNumber", typeof(int));
                for(int i = 1; i <=10; i++)
                {
                    dt.Columns.Add("Column" + i.ToString(), typeof(string));
                }
