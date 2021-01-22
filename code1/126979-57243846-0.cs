     if (((DataRowView)bindingSource1.Current).IsNew)
                    {
                    MessageBox.Show("Current Row IsNew");
                    }
                if (((DataRowView)bindingSource1.CurrencyManager.Current).Row.HasVersion(DataRowVersion.Proposed))
                    {
                    MessageBox.Show("Current Row Modified");
                    DialogResult dialogResult = MessageBox.Show("Current Row Modified", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        {
                        //do something
                        ((DataRowView)bindingSource1.CurrencyManager.Current).Row.AcceptChanges();
                        }
                    else if (dialogResult == DialogResult.No)
                        {
                        //do something else
                        ((DataRowView)bindingSource1.CurrencyManager.Current).Row.RejectChanges();
                        }
    
                    
                    }
                else { 
                    bindingSource1.MoveNext();
                    }
