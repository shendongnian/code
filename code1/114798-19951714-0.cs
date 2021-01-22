    anyElement.SizeRectChanged += OnSizeRectChanged;
    public void OnSizeRectChanged(object sender, Rect e){
        //TODO abything using the Rect class
        e.Left = e.Top = e.Width = e.Height = 50;
    }
