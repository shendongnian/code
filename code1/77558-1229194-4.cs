    public class CustomListView : ListView
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    //add OwnerDraw style...i took this idea from Reflecting against ListView
                    // bit OR is very important, otherwise you'll get an exception
                    cp.Style |= (int)ListViewDefaults.LVS_OWNERDRAWFIXED; 
    
                    return cp;
                }
            }
    
            protected override void WndProc(ref Message m)
            {
               
                base.WndProc(ref m);
               
                //if we are drawing an item then call our custom Draw.
                if (m.Msg == (int)(WMDefaults.WM_REFLECT | WMDefaults.WM_DRAWITEM))
                       ProcessDrawItem(ref m);
            }
