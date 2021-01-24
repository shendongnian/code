     private void DataLoadInGrid(DataTable dtData)
    {
        int count = gvSalaryGenerate.Rows.Count;
        foreach (GridViewRow gr in gvSalaryGenerate.Rows)
        {
            double addition = 0;
            double deduction = 0;
            Label lblEmpId = ((Label)gr.FindControl("lblEmployee_Id"));
            long empId = Convert.ToInt64(lblEmpId.Text);
            //Get Basic Salary
            Label bs = ((Label)gr.FindControl("lblBasicSalary"));
            double basicSalary = Convert.ToInt64(bs.Text);
            DataTable dtEmpData = empSalaryItemService.GetrEmployeeSalaryItemForSalaryGenerate(empId);
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                //Load Salary Item Data
                foreach (TableCell tc_ in (gvSalaryGenerate).HeaderRow.Cells)
                {
                    if (tc_.Text.Equals(dtData.Rows[i]["ITEM_NAME"].ToString()))
                    {
                        int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc_);
                        if (dtData.Rows[i]["IS_PERSONAL"].ToString() != "True")
                        {
                            if (dtData.Rows[i]["IS_PERCENT"].ToString() == "True")
                            {
                                int itemValuePrcnt = Convert.ToInt32(dtData.Rows[i]["ITEM_VALUE"].ToString());
                                double itemValue = Convert.ToDouble((basicSalary * itemValuePrcnt / 100));
                                gr.Cells[index].Text = itemValue.ToString();
                                if ((dtData.Rows[i]["ITEM_TYPE"].ToString()) == "A")
                                {
                                    addition = addition +itemValue;
                                }
                                else
                                {
                                    deduction = deduction + itemValue;
                                }
                            }
                            else
                            {
                                gr.Cells[index].Text = dtData.Rows[i]["ITEM_VALUE"].ToString();
                                if ((dtData.Rows[i]["ITEM_TYPE"].ToString()) == "A")
                                {
                                    addition = addition + Convert.ToInt64(dtData.Rows[i]["ITEM_VALUE"].ToString());
                                }
                                else
                                {
                                    deduction = deduction + Convert.ToInt64(dtData.Rows[i]["ITEM_VALUE"].ToString());
                                }
                            }
                        }
                        else
                        {
                            //Load Salary Item Employee Data                   
                            if (dtEmpData.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtEmpData.Rows.Count; j++)
                                {
                                    if (empId == Convert.ToInt64(dtEmpData.Rows[j]["EMPLOYEE_ID"]))
                                    {
                                        if (dtEmpData.Rows[j]["ITEM_NAME"].ToString() == dtData.Rows[i]["ITEM_NAME"].ToString())
                                        {
                                            foreach (TableCell tc in (gvSalaryGenerate).HeaderRow.Cells)
                                            {
                                                if (tc.Text.Equals(dtEmpData.Rows[j]["ITEM_NAME"].ToString()))
                                                {
                                                    index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                                                    if (dtEmpData.Rows[j]["IS_PERCENT"].ToString() == "True")
                                                    {
                                                        int itemValuePrcnt = Convert.ToInt32(dtEmpData.Rows[j]["ITEM_VALUE"].ToString());
                                                        double itemValue = Convert.ToDouble((basicSalary * itemValuePrcnt / 100));
                                                        gr.Cells[index].Text = itemValue.ToString();
                                                        if ((dtData.Rows[i]["ITEM_TYPE"].ToString()) == "A")
                                                        {
                                                            addition = addition + itemValue;
                                                        }
                                                        else
                                                        {
                                                            deduction = deduction + itemValue;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        gr.Cells[index].Text = dtEmpData.Rows[j]["ITEM_VALUE"].ToString();
                                                        if ((dtData.Rows[i]["ITEM_TYPE"].ToString()) == "A")
                                                        {
                                                            addition = addition + Convert.ToInt64(dtData.Rows[i]["ITEM_VALUE"].ToString());
                                                        }
                                                        else
                                                        {
                                                            deduction = deduction + Convert.ToInt64(dtData.Rows[i]["ITEM_VALUE"].ToString());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                
                            }
                        }
                        
                    }
                }
            }
            foreach (TableCell tc in (gvSalaryGenerate).HeaderRow.Cells)
            {
                if (tc.Text.Equals("EMPLOYEE_NAME"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Employee";
                }
                if (tc.Text.Equals("EMPLOYEE_CODE"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Employee Code";
                }
                if (tc.Text.Equals("CENTER_NAME"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Center";
                }
                if (tc.Text.Equals("DEPARTMENT_NAME"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Department";
                }
                if (tc.Text.Equals("DESIGNATION_NAME"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Designation";
                }
                if (tc.Text.Equals("BASIC_SALARY"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Basic Salary";
                }
                if (tc.Text.Equals("CENTER_ID"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Visible = false;
                    gr.Cells[index].Visible = false;
                }
                if (tc.Text.Equals("DEPARTMENT_ID"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Visible = false;
                    gr.Cells[index].Visible = false;
                }
                if (tc.Text.Equals("EMPLOYEE_ID"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Visible = false;
                    gr.Cells[index].Visible = false;
                }
                if (tc.Text.Equals("b1"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "";
                }
                if (tc.Text.Equals("b2"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "SL No";
                }
                if (tc.Text.Equals("b3"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "";
                }
                if (tc.Text.Equals("b4"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gvSalaryGenerate.HeaderRow.Cells[index].Text = "Held Up Reason";
                }
                if (tc.Text.Equals("Net Salary"))
                {
                    int index = (gvSalaryGenerate).HeaderRow.Cells.GetCellIndex(tc);
                    gr.Cells[index].Text = Convert.ToString(basicSalary+addition-deduction);
                }
            }
        }
    }
