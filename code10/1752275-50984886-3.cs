     string dis = txtBox.Text.ToString();
     double isId;
     if (Double.TryParse(dis, out isId))
     {
          isId = isId + 10;
          MessageBox.Show(isId.ToString());
     }
