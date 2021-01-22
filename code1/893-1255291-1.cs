public class MouseUpDownFilter : IMessageFilter {
	List<Control> ControlList = new List<Control>();
	public void WatchControl(Control buttonToWatch) {
		ControlList.Add(buttonToWatch);
	}
	public event MouseEventHandler MouseUp;
	public event MouseEventHandler MouseDown;
	public bool PreFilterMessage(ref Microsoft.WindowsCE.Forms.Message m) {
		const int WM_LBUTTONDOWN = 0x0201;
		const int WM_LBUTTONUP = 0x0202;
		// If the message code isn't one of the ones we're interested in
		// then we can stop here
		if (m.Msg != WM_LBUTTONDOWN && m.Msg != WM_LBUTTONDOWN) {
			return false;
		}
		//  see if the control is a watched button
		foreach (Control c in ControlList) {
			if (m.HWnd == c.Handle) {
				int i = (int)m.LParam;
				int x = i & 0xFFFF;
				int y = (i >> 16) & 0xFFFF;
				MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 1, x, y, 0);
				if (m.Msg == WM_LBUTTONDOWN)
					MouseDown(c, args);
				else
					MouseUp(c, args);
				// returning true means we've processed this message
				return true;
			}
		}
		return false;
	}
}
