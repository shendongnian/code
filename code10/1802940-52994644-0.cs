    private void Get_Purchasing_Amount()
                {
                    try
                    {
                        string get_P_Amount = "";
                        double var_P_Amount = 0;
                        //int var_C_Code = 0;
                        string query = "select c_code as 'code' from `db_vegetable`.`tbl_payment_master`";
                        DataTable dt_C_Code = method_Class.method_Class.FetchRecords(query);
                        if (dt_C_Code.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dt_C_Code.Rows.Count; i++)//these line generate error please check this
                            {
                                
                                //var_C_Code = Convert.ToInt32(dt_C_Code.Rows[i]["code"]);
                                if (Convert.ToInt32(dt_C_Code.Rows[i]["code"]).Equals(Convert.ToInt32(txt_Customer_Code.Text)))
                                {
                                    if (check_All.Checked.Equals(true))
                                    {
                                        get_P_Amount = "SELECT IFNULL(`purchasing`,0) AS 'purchasing' FROM `db_vegetable`.`tbl_payment_master` WHERE `c_code` = " + txt_Customer_Code.Text + "";
                                    }
                                    else
                                    {
                                        string dt_Query = "select `id` as 'id' from `db_vegetable`.`tbl_order_details`";
                                        DataTable dt_C_O = method_Class.method_Class.FetchRecords(dt_Query);
                                        if (dt_C_O.Rows.Count > 0)
                                            get_P_Amount = "SELECT IFNULL(SUM(t_price),0) as 'purchasing' FROM `db_vegetable`.`tbl_order_details` WHERE `c_code` = " + txt_Customer_Code.Text + " AND (`date` BETWEEN '" + txt_From_Date.Text + "' AND '" + txt_To_Date.Text + "')";
                                        else
                                            lbl_Purchasing_Amount.Text = "0";
                                    }
                                    DataTable dt = method_Class.method_Class.FetchRecords(get_P_Amount);
                                    var_P_Amount = Convert.ToDouble(dt.Rows[0]["purchasing"]);
                                    lbl_Purchasing_Amount.Text = var_P_Amount.ToString();
                                    break;
                                }
                                else
                                {
                                    lbl_Purchasing_Amount.Text = "0";
                                }
                            }
                        }
                        else
                        {
                            lbl_Purchasing_Amount.Text = "0";
                        }
                    }
                    catch (Exception)
                    {
                      
                    }
                }
