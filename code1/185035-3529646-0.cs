    string[] listOfControls; //initialize as you will
    ContentPlaceHolder cph = this.Master.FindControl("TopContentPlaceHolder") as ContentPlaceHolder;
    for (int i=0; i<listOfControls.Length; i++)
    {
       UserControl uc = this.LoadControl(listOfControls[i]) as UserControl;
       if ((cph != null) && (uc != null))
       {
           cph.Controls.Add(uc);
       }
    }
