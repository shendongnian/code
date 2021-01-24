    DataTable dt = dsPage.Tables[0];
                string strArr = dt.Rows[0]["Training_Days"].ToString();
                string[] Arr = strArr.Split(',');
                for (int j = 0; j < Arr.Length; j++)
                {
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        if (CheckBoxList1.Items.FindByText(Arr[i]) != null)
                        {
                            CheckBoxList1.Items.FindByText(Arr[i]).Selected = true;
                            continue;
                        }
                    }
                }
