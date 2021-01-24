    var action = new Action(() =>
    {
          var userInput = MessageBox.Show("Are tasks A, B, C running?", "winCaption", MessageBoxButtons.YesNo);
          if (userInput == DialogResult.Yes)
          {
               // PASS
          }
          else
          {
                // FAIL
          }
    });
    new Thread(new ThreadStart(action)).Start();
