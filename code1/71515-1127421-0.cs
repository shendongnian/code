    private void MyListView_Click(object sender, EventArgs e)
    {
       ListView l = (ListView)sender;
       if (l.SelectedItem != null)
       {
          MyClass obj = l.SelectedItem.Tag as MyClass;
          if (obj != null)
          {
             obj.Method();
          }
       }
    }
