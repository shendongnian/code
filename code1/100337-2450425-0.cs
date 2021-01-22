    private void OnManipulationStarted(object sender, RoutedEventArgs args)
{
	ScatterViewItem svi = args.OriginalSource as ScatterViewItem;
	if (svi != null)// && DragDropScatterView.GetAllowDrag(svi))
	{
		svi.BeginDragDrop(svi.DataContext);
	}
