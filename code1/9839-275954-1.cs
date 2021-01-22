	reportView.HScrollEvent += new ScrollEventHandler((sender,e) => {
		if ((ushort) e.NewValue != SB_THUMBTRACK)
			SendMessage(summaryView.Handle, WM_HSCROLL, (IntPtr) e.NewValue, IntPtr.Zero);
		else {
			int newPos = e.NewValue >> 16;
			int oldPos = GetScrollPos(reportView .Handle, SB_HORZ);					
			int pos    = GetScrollPos(summaryView.Handle, SB_HORZ);
			int lst;
					
			if (pos != newPos)
				if      (pos<newPos && oldPos<newPos) do { lst=pos; SendMessage(summaryView.Handle,WM_HSCROLL,(IntPtr)SB_LINERIGHT,IntPtr.Zero); } while ((pos=GetScrollPos(summaryView.Handle,SB_HORZ)) < newPos && pos!=lst);
				else if (pos>newPos && oldPos>newPos) do { lst=pos; SendMessage(summaryView.Handle,WM_HSCROLL,(IntPtr)SB_LINELEFT, IntPtr.Zero); } while ((pos=GetScrollPos(summaryView.Handle,SB_HORZ)) > newPos && pos!=lst);
			}
		});
