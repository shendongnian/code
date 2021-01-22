    StringBuilder sb = new StringBuilder();
    foreach (Control c in this.Controls)
    {
    	if (c.GetType() == typeof(System.Windows.Forms.ComboBox))
    	{
    		sb.AppendLine(c.Text); // ...
    	}
    }
