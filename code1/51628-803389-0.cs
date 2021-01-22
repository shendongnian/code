    PFA(form => UpdateTextBox(form.Richbox1,"Test"));
    
    
    public void UpdateTextBox(RichTextBox box,string text)
    {
        
       if (box.Name=="Richbox1")
       {
           text+="\n";
       }
    
       box.AppendText(text);
    }
