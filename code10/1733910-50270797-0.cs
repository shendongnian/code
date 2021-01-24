    protected HyperLink AddHyperLink(string cell, string strURL)
    {
        HyperLink h1 = new HyperLink();
        TableCell cells = new TableCell();
        try
        {
            h1.Text = cell;
            h1.Font.Underline = true;
            h1.Target = "_blank";
            h1.NavigateUrl = strURL;
            h1.Attributes.Add("style", "color:black");
            cells.Controls.Add(h1);
        }
        catch(Exception ex)
        {
        }
        return h1;
    }
