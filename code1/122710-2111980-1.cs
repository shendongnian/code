      void YourRadioButton_CheckChanged(Object sender, EventArgs e) 
      {
         txt1.Visible = !YourRadioButton.Checked;
         txt2.Visible = !YourRadioButton.Checked;
         // and so on... 
      }
