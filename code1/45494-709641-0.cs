    [DllImport ("user32.dll")]
    public static extern int GetKeyboardState( byte[] keystate );
    
            
    private void Form1_KeyDown( object sender, KeyEventArgs e )
    {
       byte[] keys = new byte[255];
    
       GetKeyboardState (keys);
    
       if( keys[(int)Keys.Up] == 129 && keys[(int)Keys.Right] == 129 )
       {
           Console.WriteLine ("Up Arrow key and Right Arrow key down.");
       }
    }
