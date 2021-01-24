    // sv - the ScrollViewer to which this event handler is listening
    // lv - the ListView associated with "sv"
    private void inf_scroll(object sender, ScrollChangedEventArgs e) {
        for (int i = 0; i < e.VerticalChange; i++) {
            object tmp = lv.Items[0];
            lv.Items.RemoveAt(0);
            lv.Items.Add(tmp);
        }
        for (int i = 0; i > e.VerticalChange; i--) {
            object tmp = lv.Items[lv.Items.Count - 1];
            lv.Items.RemoveAt(lv.Items.Count - 1);
            lv.Items.Insert(0, tmp);
        }
        lv.ScrollChanged -= inf_scroll;        // remove the handler temporarily
        sv.ScrollToVerticalOffset(sv.VerticalOffset - e.VerticalChange);
        Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>{
            sv.ScrollChanged += inf_scroll;    // add the handler back after the scrolling has occurred to avoid recursive scrolling
        }));
    }
