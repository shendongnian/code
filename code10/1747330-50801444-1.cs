    public void OnLieferadresseRowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
    {
        var row = e.Row as GridViewRow;
        if (e.EditAction == GridViewEditAction.Cancel)
        {
            return;
        }
        else if (e.EditOperationType == GridViewEditOperationType.Insert)
        {
            //Insert the entry in the data base
        }
        else if (e.EditOperationType == GridViewEditOperationType.Edit)
        {
            //Update the entry in the data base
        }
    }
