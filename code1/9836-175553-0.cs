    public class MyListView : System.Windows.Forms.ListView
    {
        const int WM_HSCROLL = 0x0114;
        const int WM_VSCROLL = 0x0115;
    
        private ScrollEventHandler evtHScroll_m;
        private ScrollEventHandler evtVScroll_m;
    
        public event ScrollEventHandler OnHScroll
        {
            add
            {
                evtHScroll_m += value;
            }
            remove
            {
                evtHScroll_m -= value;
            }
        }
    
        public event ScrollEventHandler OnHVcroll
        {
            add
            {
                evtVScroll_m += value;
            }
            remove
            {
                evtVScroll_m -= value;
            }
        }
    
        protected override void WndProc(ref System.Windows.Forms.Message msg) 
        { 
            if (msg.Msg == WM_HSCROLL && evtHScroll_m != null) 
    		    {
                evtHScroll_m(this,new ScrollEventArgs(ScrollEventType.ThumbTrack, msg.WParam.ToInt32()));
    		    }
    
            if (msg.Msg == WM_VSCROLL && evtVScroll_m != null)  
            {
                evtVScroll_m(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, msg.WParam.ToInt32()));
            }
            base.WndProc(ref msg); 
        }
