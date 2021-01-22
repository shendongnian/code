        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                foreach (System.Web.UI.Control ctl in cell.Controls)
                {
                    if (ctl.GetType().ToString().Contains("DataControlLinkButton"))
                    {
                        String headerText = ((LinkButton)ctl).Text;
                        cell.Attributes.Add("title", headerTooltips[headerText]);
                    }
                }
            }
        }
