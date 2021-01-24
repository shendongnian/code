    private void createButton(string name, int x, int y)
          {
              // Create button
              Button btn = new Button();
    		  
    		  // Set button name
              btn.Name = name;
    		  
    		  // Set location
              btn.Location = new Point(x, y);
    		  
              //Hook our button up to our generic button handler
              btn.Click += new EventHandler(btn_Click);
    		  
    		  // Add it to the main panel
    		  // panel1 is your application name
              panel1.Controls.Add(
          }
     void btn_Click(object sender, EventArgs e)
          {
              MessageBox.Show("This is the handler of the button that we created");
          }
