    [DllImport("gdi32.dll", CharSet=CharSet.Auto)] 
    public static extern int SetTextCharacterExtra( 
        IntPtr hdc,    // DC handle
        int nCharExtra // extra-space value 
    ); 
    
    public void Draw(Graphics g) 
    { 
        IntPtr hdc = g.GetHdc(); 
        SetTextCharacterExtra(hdc, 24); //set spacing between characters 
        g.ReleaseHdc(hdc); 
        e.Graphics.DrawString("str",this.Font,Brushes.Black,0,0); 
    }  
