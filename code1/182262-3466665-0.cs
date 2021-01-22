     private void Button1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
     {
      if (e.Button == MouseButtons.Right)
      {
        PropertyGridForm f = new PropertyGridForm();
        f.PropertyGrid.SelectedObject = Button1; // (or sender?) whatever you need
        f.Location = e.Location;
        f.Show(); //or ShowDialog? 
      }
     }
