    private void OnCursorDrop(object sender, SurfaceDragDropEventArgs args)
{
	SurfaceDragCursor droppingCursor = args.Cursor;
	
	
	// Add dropping Item that was from another drag source.
	if (!scatterView1.Items.Contains(droppingCursor.Data)){
		scatterView1.Items.Add(droppingCursor.Data);
	
		var svi = scatterView1.ItemContainerGenerator.ContainerFromItem(droppingCursor.Data) as ScatterViewItem;
		if (svi != null){
			svi.Center = droppingCursor.GetPosition(scatterView1);
			svi.Orientation = droppingCursor.GetOrientation(scatterView1);
			svi.Height = droppingCursor.Visual.ActualHeight;
			svi.Width = droppingCursor.Visual.ActualWidth;
			svi.SetRelativeZIndex(RelativeScatterViewZIndex.Topmost);
		}
	}
