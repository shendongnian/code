    private void button1_Click ( object sender, EventArgs e )
    {           
            if( (ModifierKeys  & Keys.Control) == Keys.Control )
            {
                ControlClickMethod();    
            }
            else
            {
                ClickMethod();
            }
        }
        private void ControlClickMethod()
        {
            MessageBox.Show( "Control is pressed" );
        }
        private void ClickMethod()
        {
            MessageBox.Show ( "Control is not pressed" );
        }
