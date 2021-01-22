    private void SendLabelsToBack()
    {
        foreach (UserLabel lbl in userContainer.Controls)
        {
            lbl.SendToBack();
            lbl.Invalidate();
        }
    }
