    public event EventHandler DataBoundGrid {
      add { ctlOverviewGridView.DataBound += value; }
      remove { ctlOverviewGridView.DataBound -= value; }
    }
    
    ctlOverview.DataBoundGrid += (sender, args) => {
      ((sender as ASPxGridView).Columns["YourColumnName"] as GridViewDataTextColumn).PropertiesTextEdit.EncodeHtml = false;
    };
