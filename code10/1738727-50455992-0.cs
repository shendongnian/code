    //Create a delegate     
    public delegate void ModifyTabPage();
    
    //Create an object in the form for delegate and instatiate with the method which modifies tabpage
    public ModifyTabPage myDelegate;
    myDelegate = new ModifyTabPage(ModifyTabPageMethod);
      
    
    public void ModifyTabPageMethod()
    {
            page++;
            if (page == 4)
            {
                page = 0;
            }
            tabControl1.SelectedIndex = page;
            tabControl1.Refresh();
    }
    
    
    
    //using invoke access it from the data recived event of your serialize port.    
    myFormControl1.Invoke(myFormControl1.myDelegate);
