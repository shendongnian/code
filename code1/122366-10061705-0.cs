        private int counter=0;
        private void CreateButton_Click(object sender, EventArgs e)
        {
            //Create new button.
            Button button = new Button();
            //Set name for a button to recognize it later.
            button.Name = "Butt"+counter;
           // you can added other attribute here.
            button.Text = "New";
            button.Location = new Point(70,70);
            button.Size = new Size(100, 100);
           // Increase counter for adding new button later.
            counter++;
            // add click event to the button.
            button.Click += new EventHandler(NewButton_Click);
       }
        // In event method.
        private void NewButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender; 
            
            for (int i = 0; i < counter; i++)
            {
                if (btn.Name == ("Butt" + i))
                {
                    // When find specific button do what do you want.
                    //Then exit from loop by break.
                    break;
                }
            }
        }
