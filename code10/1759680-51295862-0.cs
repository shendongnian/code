       DataGridViewComboBoxColumn grdCol = new DataGridViewComboBoxColumn();
       grdCol.DataSource = discountTbl;
       grdCol.DataPropertyName = "DiscountId";
       grdCol.DisplayMember = "DiscountName";
       grdCol.HeaderText = "Discount";
       grdCol.Name = "DiscountId";
       grdCol.ValueType = typeof(System.Int32);
    
       dgv.Columns.Add(grdCol);
