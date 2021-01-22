    void A()  
    {  
      Popup parameter = new Popup();  
      buttonClose.Click += (sender, e) => { buttonClose_Click(sender, e, parameter); };  
    }  
     
    static void buttonClose_Click(object sender, EventArgs e, Popup parameter)     
    {     
      MakeSomethingWithPopupParameter(parameter);  
    }
