            public Input(Window screen)
        {
            screen.GetScreen().KeyPreview = true;
            screen.GetScreen().KeyDown += Input_KeyDown;
        }
        private void Input_KeyDown( object sender, KeyEventArgs e )
        {
            if(e.KeyCode == Keys.A)
            {
                Console.WriteLine("you pressed 'A' !");
            }
        }
