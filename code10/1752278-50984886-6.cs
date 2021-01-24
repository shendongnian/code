     string dis = txtBox.Text;
     double isId;
     if (Double.TryParse(dis, out isId))
     {
          isId = isId + 10;
          MessageBox.Show(isId.ToString());
     }
     else
     {
        MessageBox.Show("Please Only enter Number");
     }
