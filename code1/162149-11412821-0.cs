            //If U Have Add CheckBox To Ur Datagridview
                    int rowIndex = -1;
                    DataGridViewCheckBoxCell oCell;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        oCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                        if (true == bChecked)
                        {
                            rowIndex = row.Index;
                           //ur code
                        }
                    }
