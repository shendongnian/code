    var boxes =  from Control c in this.Controls
                 where c.GetType() == typeof(System.Windows.Forms.ComboBox)
                 select c;
    
    StringBuilder sb = new StringBuilder();
    foreach (Control c in boxes)
    {
    	sb.AppendLine(c.Text); // ...
    }
