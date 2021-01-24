    public void ChangeView(int view)
    {
        listViewModel.View = view;
        listView.Measure(new Size(listView.ActualWidth, listView.ActualHeight));
        listView.Arrange(new Rect(0, 0, listView.ActualWidth, listView.ActualHeight));
        ScrollContentPresenter scrollContent = FindChild<ScrollContentPresenter>(this.listView);
    }
