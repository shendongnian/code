    string[] placeholders;
    string[] listOfControls; //initialize as you will
        
        for (int i=0; i<listOfControls.Length; i++)
        {
           ContentPlaceHolder cph = this.Master.FindControl(placeholders[i]) as ContentPlaceHolder;
           UserControl uc = this.LoadControl(listOfControls[i]) as UserControl;
           if ((cph != null) && (uc != null))
           {
               cph.Controls.Add(uc);
           }
        }
