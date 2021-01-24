    protected void SendButton_Click(object sender, EventArgs e)
    {
        UserControl uc = new UserControl();
        bool Ok = false;
        string userControl = "";
        string ID = "0";
        ID = UCid.Text;
        if(ID == "1")
        {
            userControl = MapPath(@"~\UCtest_one.ascx");
            Ok = true;
        }
        else if (ID == "2")
        {
            userControl = MapPath(@"~\UCtest_two.ascx");
            Ok = true;
        }
        else
        {
            Response.Write("Eror!!! Enter only 1 or 2");
            Ok = false;
        }
        if (Ok)
        {
   
     uc = LoadControl(userControl) as UserControl;
            ViewUC.Controls.Add(uc);
        }
        else
        {
            Response.Write("Eror!!!");
        }
    }
