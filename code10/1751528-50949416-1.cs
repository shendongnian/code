    DateTime Compdate;
    if (!String.IsNullOrEmpty(txtRefDate.Text) && DateTime.TryParse(txtRefDate.Text, out Compdate))
    {
        obj.RefrenceDate = Compdate.Date;
    }
