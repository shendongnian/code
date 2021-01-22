    protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "ADD")
            {
                CATEGORY cat = new CATEGORY
                {
                    NAME = tbxCategory.Text.Trim(),
                    TOTALSALEVALUE = tbxSaleValue.Text.Trim(),
                    PROFIT = tbxProfit.Text.Trim()
                };
                dm.AddCategory(cat, tbxCategory.Text.Trim());
            }
            else
            {
                var c = getCategory();
                c.NAME = tbxCategory.Text.Trim();
                c.TOTALSALEVALUE = tbxSaleValue.Text.Trim();
                c.PROFIT = tbxProfit.Text.Trim();
                dm.UpdateCategory(c);
            }
            btnSearchCat_Click(btnSearchCat, e);
        }
