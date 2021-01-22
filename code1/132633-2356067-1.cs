    private static void setControlTextThreadSafe( Control control, string text )
    {
       if (control.InvokeRequired)
       {
          control.Invoke( new SetControlTextDelegate( setControlText ), control, text );
       }
       else
       {
          setControlText( control, text );
       }
    }
        
    private delegate void SetControlTextDelegate( Control control, string text );
        
    private static void setControlText( Control control, string text )
    {
       control.Text = text;
    }
