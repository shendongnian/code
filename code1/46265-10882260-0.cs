    // ...
    GridViewRow headerRow = GridView1.HeaderRow;
    foreach (TableCell tableCell in headerRow.Cells)
    {
        if (tableCell.HasControls())
        {
            LinkButton button = tableCell.Controls[0] as LinkButton;
            if (button != null)
            {                                            
                if (sortExp == button.CommandArgument)
                {
                    Image image = new Image();
                    if (sortDir == "ASC")
                    {
                        image.ImageUrl = "/_layouts/Document LibraryManager/icon_ascending.gif";
                        tableCell.Controls.Add(image);
                    }
                    else
                    {
                        image.ImageUrl = "/_layouts/Document LibraryManager/icon_descending.gif";
                        tableCell.Controls.Add(image);
                    }
                }
            }
        }
    }
}
