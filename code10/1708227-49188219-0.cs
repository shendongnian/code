    private bool ScrollViewer1Scrolled, ScrollViewer2Scrolled;
    private void SyncScrollViewers()
    {
        ScrollViewer scrollViewer1 = ListViewOne.GetScrollViewer();
        ScrollViewer scrollViewer2 = ListViewTwo.GetScrollViewer();
    
        if (scrollViewer1 == null || scrollViewer2 == null) return;
        scrollViewer1.ViewChanged += (s, e) =>
        {
            ScrollViewer1Scrolled = true;
            if (!ScrollViewer2Scrolled)
            {
                scrollViewer2.ChangeView(null, scrollViewer1.VerticalOffset, null, false);
                Debug.WriteLine("scrollViewer2 scrolled");
            }
            ScrollViewer2Scrolled = false;
        };
    
        scrollViewer2.ViewChanged += (s, e) =>
        {
            ScrollViewer2Scrolled = true;
            if (!ScrollViewer1Scrolled)
            {
                scrollViewer1.ChangeView(null, scrollViewer2.VerticalOffset, null, false);
                Debug.WriteLine("scrollViewer1 scrolled");
            }
            ScrollViewer1Scrolled = false;
        };
    }
