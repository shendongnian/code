    SCROLLINFO scrollinfo = new SCROLLINFO();
    scrollinfo.cbSize = Marshal.SizeOf(scrollinfo);
    scrollinfo.fMask = ApiConstants.SIF_ALL;
    bool flag1 = User32.GetScrollInfo(_RichTextBox.Handle, ApiConstants.SB_HORZ, ref scrollinfo);
    Logging.LogMessage("Resize - ScrollInfo: Max: " + scrollinfo.nMax + " Min: " + scrollinfo.nMin + " Page: " + scrollinfo.nPage + " Pos: " + scrollinfo.nPos + " TrackPos: " + scrollinfo.nTrackPos + " || RichtTextBox.RightMargin == " + _RichTextBox.RightMargin + " || RichTextBox.WordWrap == " + WordWrap + " / " + _RichTextBox.WordWrap + " Size: " + Size + " ClientRectangle: " + _RichTextBox.ClientSize);
    switch (WordWrap)
    {
        case WordWrap.WrapToControl:
        {
            if (scrollinfo.nMax > _RichTextBox.ClientSize.Width)
            {
                User32.ShowScrollBar(_RichTextBox.Handle, ApiConstants.SB_HORZ, false);
            }
            break;
        }
        case WordWrap.WrapToPrintDocument:
        {
            if (scrollinfo.nMax > _PrintableWidth)
            {
                User32.ShowScrollBar(_RichTextBox.Handle, ApiConstants.SB_HORZ, false);
            }
            break;
        }
    }
