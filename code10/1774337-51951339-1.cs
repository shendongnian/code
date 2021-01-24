	    private void EnableAutoScroll(Label label, ListView listView)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(logListView.IsVisible)
                    logListView.ScrollTo(label, ScrollToPosition.End, false);
            });
        }
