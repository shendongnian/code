    Panel panel = new Panel();
    string myString = "This is a textbox: ##";
    // some parsing logic
    string[] arr = { "This is a textBox", "##" };
    
    foreach(var item in arr)
    {
      if (item == "##"){
        TextBox tb = new TextBox();
        panel.Controls.Add(tb);
      }
      else{
        Label l = new Label();
        l.Text = item;
        panel.Controls.Add(l);
      }
    }
    
    your_plaaceholder.Controls.Add(panel);
