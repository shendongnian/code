    const int WM_DRAWCLIPBOARD = 36;
    protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
    
            //check if current operation is a clipboard
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                try
                {
                    if (Clipboard.GetText() == "123")
                    {
                        MessageBox.Show(Clipboard.GetText());
                        Clipboard.Clear();
                        return;
                    }
                }
                catch(Exception e)
                {
    
                }
            }
       } 
