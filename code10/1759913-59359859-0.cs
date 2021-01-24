    private void LstVehicles_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.Control && (e.KeyCode == Keys.C))
       {
          Clipboard.SetText(this.yourListBoxName.SelectedItem.ToString());
       }
    }
