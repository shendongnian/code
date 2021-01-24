    var action = new Action(() =>
    {
          var userInput = MessageBox.Show("Are tasks A, B, C running?", "winCaption", MessageBoxButtons.YesNo);
          if (userInput == DialogResult.Yes)
          {
               // PASS
               // exit while loop
          }
          else
          {
                // FAIL
                // exit while loop
          }
    });
    new Thread(new ThreadStart(action)).Start();
