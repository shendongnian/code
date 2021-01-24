    private void timer1_Tick(object sender, EventArgs e)
            {
                 if(progressBar1.Value<100) // set progressBar max value to 100
                  {
                         // if the value smaller than 100, will increment.
                        this.progressBar1.Increment(1);
                  }
              else{
                     timer1.Stop(); // Important to stop the timer
                      // here you change the background image of the form.
                      this.BackgroundImage = // choose ur image location.
                  }
            }
