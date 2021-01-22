      public Form1()
      {
         InitializeComponent();
         // Dedicate a different event handler method for each button
         for (int i = 0; i < 5; i++)
         {
            Button button = new Button();
            button.Location = new Point(20, 30 * i + 10);
            switch (i)
            {
               case 0:
                  button.Click += new EventHandler(ButtonClick);
                  break;
               case 1:
                  button.Click += new EventHandler(ButtonClick2);
                  break;
               //...
            }
            this.Controls.Add(button);
         }
         // Use a single event handler method, storing the button index in the Tag property
         for (int i = 0; i < 5; i++)
         {
            Button button = new Button();
            button.Location = new Point(160, 30 * i + 10);
            button.Click += new EventHandler(ButtonClickOneEvent);
            button.Tag = i;
            this.Controls.Add(button);
         }
         // Use a single event handler method, "capturing" the button index for each
         // button with an anonymous method
         for (int i = 0; i < 5; i++)
         {
            int index = i;
            Button button = new Button();
            button.Location = new Point(300, 30 * i + 10);
            button.Click += (sender, e) => ButtonClickOneEventDirect(index);
            this.Controls.Add(button);
         }
      }
      void ButtonClick(object sender, EventArgs e)
      {
         // First Button Clicked
      }
      void ButtonClick2(object sender, EventArgs e)
      {
         // Second Button Clicked
      }
      void ButtonClickOneEvent(object sender, EventArgs e)
      {
         Button button = sender as Button;
         if (button != null)
         {
            // now you know the button that was clicked
            switch ((int)button.Tag)
            {
               case 0:
                  // First Button Clicked
                  break;
               case 1:
                  // Second Button Clicked
                  break;
               // ...
            }
         }
      }
      void ButtonClickOneEventDirect(int i)
      {
          switch (i)
          {
             case 0:
                // First Button Clicked
                break;
             case 1:
                // Second Button Clicked
                break;
             // ...
          }
      }
