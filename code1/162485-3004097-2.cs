    public void SaveData()
    {
        myBusinessObjectCollection = new myBusinessObjectCollection();
        foreach (GridViewRow row in myGridView.Rows)
        {
            myBusinessObjectCollection.Add(
                new myBusinessObject
                {
                    C1 = ((TextBox)row.FindControl("txtNewC1")).Text,
                    C2 = ((TextBox)row.FindControl("txtNewC2")).Text
                });
        }
        myBusinessObjectCollection.Save();
    }
