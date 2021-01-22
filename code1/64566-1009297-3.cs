    private void OnScrollUp(object sender, RoutedEventArgs e)
	{
		var scrollViwer = GetScrollViewer(uiListView) as ScrollViewer;
		if (scrollViwer != null)
		{
           // Logical Scrolling by Item
		   // scrollViwer.LineUp();
           // Physical Scrolling by Offset
           scrollViwer.ScrollToVerticalOffset(scrollViwer.VerticalOffset + 3);
		}
	}
	private void OnScrollDown(object sender, RoutedEventArgs e)
	{
		var scrollViwer = GetScrollViewer(uiListView) as ScrollViewer;
		if (scrollViwer != null)
		{
            // Logical Scrolling by Item
		    // scrollViwer.LineDown();
            // Physical Scrolling by Offset
            scrollViwer.ScrollToVerticalOffset(scrollViwer.VerticalOffset + 3);
		}
	}
    <DockPanel>
	    <Button DockPanel.Dock="Top"
				Content="Scroll Up"
				Click="OnScrollUp" />
		<Button DockPanel.Dock="Bottom"
				Content="Scroll Down"
				Click="OnScrollDown" />
		<ListView x:Name="uiListView">
			<!-- Content -->
		</ListView>
	</DockPanel>
