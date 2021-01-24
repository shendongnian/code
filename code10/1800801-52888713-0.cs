    void dT_Tick(object sender, EventArgs e)
    {
          if (counter % 2 != 0) {
             imageBox1.Source = images[counter];
             imageBox1.Visible = true;
             imageBox2.Visible = false;
          }
          else {
             imageBox2.Source = images[counter];
             imageBox2.Visible = true;
             imageBox1.Visible = false;
          }
          counter++;
    
          if (counter == 1000)
          {
            dT.Stop();
          }
    } 
