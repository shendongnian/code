    private void textBox_TextChanged(object sender, EventArgs e)
      {
        foreach(string County in MyCountyList)
        {
          if(County.StartsWith(textBox.Text))
          {
          //Do work (Add to list or whatever)
          }
        }
      }
