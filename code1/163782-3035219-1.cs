    private void getrowvalues()
    {
        string combinedvalues;
        List<string> combinedValuesList = new List<string>();
        
        foreach (GridViewRow row in gvOrderProducts.Rows)
        {
            string prodname = ((Label)row.FindControl("lblProductName")).Text;
            string txtvalues = ((TextBox)row.FindControl("txtQuantity")).Text;
        
            combinedvalues = prodname + "|" + txtvalues;
            combinedValuesList.Add(combinedvalues);
        }
        // use combinedValuesList or combinedValuesList.ToArray()
    }
