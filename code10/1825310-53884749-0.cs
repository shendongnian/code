       public AddButton()
        {          
            var newButton = new Button { Text = "Button 1" };
            newButton.Click += MyEventListener;
            this.Controls.Add(newButton);            
        }
        private void MyEventListener(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MessageBox.Show($"{button.Text} says: Hello, world");
        }
