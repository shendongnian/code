    protected override void OnPreRender(EventArgs e)
    {
        if ( (this.ShowHeader == true && this.Rows.Count > 0)
          || (this.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            this.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (this.ShowFooter == true && this.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            this.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        base.OnPreRender(e);
    }
