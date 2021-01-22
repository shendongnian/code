    using System.Linq;
    
    private void GridView_OnItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var buttons = e.Row.Cells.OfType<DataControlFieldCell>().SelectMany(item => item.Controls.OfType<ImageButton>());
            foreach (ImageButton imageButton in buttons)
            {
                var argument = imageButton.CommandName + "$" + imageButton.CommandArgument;
                imageButton.OnClientClick = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView, argument) + "; return false;";
            }
        }
    }
