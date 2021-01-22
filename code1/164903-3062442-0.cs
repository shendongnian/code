    public void ShowNextPage()
    {
       InvokeOnScrollViewer(listBox, viewer => viewer.PageDown());
    }
    public void ShowPriorPage()
    {
       InvokeOnScrollViewer(listBox, viewer => viewer.PageUp());
    }
    public void InvokeOnScrollViewer(ItemsControl control, Action<ScrollViewer> action)
    {
      for(Visual vis = control as Visual; VisualTreeHelper.GetChildCount(vis)!=0; vis = VisualTreeHelper.GetChild(vis, 0))
        if(vis is ScrollViewer)
        {
          Action((ScrollViewer)vis);
          break;
        }
    }
