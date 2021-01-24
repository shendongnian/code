    private void AddTotalRow(string labelText, string value)
    {
         GridViewRow row = new GridViewRow(0,0, DataControlwRowType.DataRow, DataControlRowState.Normal);
         row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
         row.Cells.AddRange(new TableCell[4] { new TableCell(),
             new TableCell{ Text = labelText, HorizontalAlign = HorizontalAlign.Right }.
             new TableCell{ Text = value, HorizontalAlign = HorizontalAlign.Right),
             //Calling HyperLinkCell method which will return a TableCell with HyperLink in it.
             HyperLinkCell(value, "http://www.google.com")
            });
        gvData.Rows.Add(row);
     }
     
     protected TableCell (string text, string url)
     {
         //Create new Cell
         TableCell cell = new TableCell();
        //Create new HyperLink.
         HyperLink link = new HyperLink();
         try
         {
             link.Text = text;
             link.Font.UnderLine = true;
             link.Target = "_blank";
             link.NavigationUrl = url;
             link.Attributes.Add("style", "color:Black;");
             //Add hyperlink to the cell.
             cell.Controls.Add(link);
         }
         catch(Exception ex)
         {
         }
         //Return Cell with HyperLink.
         return cell;
     }
         
