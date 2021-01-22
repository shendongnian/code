    public class GridView : System.Web.UI.WebControls.GridView
    {
       protected override void OnSorted(EventArgs e)
       {
          string AscCSS = ...;
          string DescCSS= ...;
      
          foreach (DataControlField field in this.Columns)
          {
             // strip off the old ascending/descending icon
            field.HeaderStyle.CssClass.Remove();
             // See where to add the sort ascending/descending icon
             if (field.SortExpression == this.SortExpression)
             {
                if (this.SortDirection == SortDirection.Ascending)
                   field.HeaderStyle.CssClass = AscCSS;
                else
                   field.HeaderStyle.CssClass = DescCss;
             }
          }
          base.OnSorted(e);
       }
    }
