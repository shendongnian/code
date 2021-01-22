      void LinkButton_Click(Object sender, EventArgs e) 
      {
         // First enable all buttons
         btn1.Enabled = true;
         btn2.Enabled = true;
         // Then disable the clicked button
         (sender as Control).Enabled = false;
         ...
      }
