    [DllImport ("user32.dll")]
    public static extern int GetKeyboardState( byte[] keystate );
    
            
    private void Form1_KeyDown( object sender, KeyEventArgs e )
    {
       byte[] keys = new byte[256];
    
       GetKeyboardState (keys);
    
       if ((keys[(int)Keys.Up] & keys[(int)Keys.Right] & 128 ) == 128)
       {
           Console.WriteLine ("Up Arrow key and Right Arrow key down.");
       }
    }
