     foreach (DataRow row in ecommDS.Tables["EcommData"].Rows)
                {
                    
                    //string statCode = ""
                    string prdCode = "";   //declaring var for getting string format from ecomm
                    string checking = "";
                    prdCode = row["PRD-CDE"].ToString();
                    checking = row["SUBS-NUM"].ToString();
                   
                    if(checking != subsNum)
                    {
                        continue;
                    }
