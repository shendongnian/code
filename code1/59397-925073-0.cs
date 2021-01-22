    private void timer1_Tick(object sender, EventArgs e)
    {
       // ...
       AddTextToListBox("\n\n işlem bitti...");
    }
    
    private void AddTextToListBox(string text)
    {
       if(list1.InvokeRequired)
       {
          list1.Invoke(new MethodInvoker(AddTextToListBox), new object[] { text }); 
          return;
       }
    
       list1.Items.Add(text);
    }
