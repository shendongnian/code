      MyClass c = new MyClass();
      listBox1.Items.Add(c);
      private void listBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            if(e.ListItem is MyClass)
            {
                e.Value = ((MyClass)e.ListItem).ToString();
            }
            else
            {
                e.Value = "Unknown item added";
            }
        }
