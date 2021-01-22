       foreach (Control c in table.Controls)
       {
          if (c is TextBox)
          {
             // Do things, that works
          }
          else if (c is CheckedListBox)
          { 
             CheckedListBox box = (CheckedListBox)c;
             // Do something with box
          }
       }
