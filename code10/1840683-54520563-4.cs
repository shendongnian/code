    for (int i = 0; i < 5; i++)
    {
        WebUserControl1 cuc = (WebUserControl1)LoadControl("~/WebUserControl1.ascx");
        cuc.ID = "Control" + i;
        Panel1.Controls.Add(cuc);
        cuc.myTask(myParameter);
    }
