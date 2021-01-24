    private void UpdateTextBoxFontStyle()
    {
       var fs = System.Drawing.FontStyle.Regular;
    
       var checkedStyles = Controls.OfType<CheckBox>()
              .Where(x => x.Checked)
              .Where(x => x.Tag is System.Drawing.FontStyle)
              .Select(x => (System.Drawing.FontStyle) x.Tag).ToList();
    
       foreach (var style in checkedStyles) fs |= style;
       lblTestFont.Font = new System.Drawing.Font("Segoe UI", 9f, fs, System.Drawing.GraphicsUnit.Point);
    }
