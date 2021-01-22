	public class MyListView : ListView
	{
		public event ScrollEventHandler HScrollEvent;
			
		protected override void WndProc(ref System.Windows.Forms.Message msg) 
		{
			if (msg.Msg==WM_HSCROLL && HScrollEvent != null)
				HScrollEvent(this,new ScrollEventArgs(ScrollEventType.ThumbTrack, (int)msg.WParam));
				
			base.WndProc(ref msg);
		}
	}
