    private void dgv_sales_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
            {
            try
            {
                if (dgv_sales.CurrentCell.ColumnIndex==0)
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname!=null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodname.AutoCompleteCustomSource = ClientListDropDown();
                        prodname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (dgv_sales.CurrentCell.ColumnIndex==7)
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname != null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodname.AutoCompleteCustomSource = BatchNoDropDown();
                        prodname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname != null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.None;
                       
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }
