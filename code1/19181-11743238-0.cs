    base.WndProc(ref m);
    // if click outside dialog -> Close Dlg
    if (m.Msg == NativeConstants.WM_NCACTIVATE) //0x86
    {
        if (this.Visible)
        {
            if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
                this.Close();
        }
    }
}
