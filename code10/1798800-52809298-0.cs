    private void AddProductsTabbedPanel()
        {
            string queryString = @"SELECT VALUE P FROM Tblproducts as P";
            foreach (TabPage tp in tabControl1.TabPages)
            {
                ObjectContext context = ((IObjectContextAdapter)cse).ObjectContext;
                ObjectQuery<TblProduct> filteredproduct = new ObjectQuery<TblProduct>(queryString, context);
                foreach (TblProduct tprod in filteredproduct)
                {
                    Button b = new Button();
                    b.Text = tprod.Description;
                    tp.Controls.Add(b);
                }
            }
        }
