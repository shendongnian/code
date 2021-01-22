	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		bool mouseDown = false; // Set to 'true' when mouse is held down.
		Point mouseDownPos;		// The point where the mouse button was clicked down.
		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			// Capture and track the mouse.
			mouseDown = true;
			mouseDownPos = e.GetPosition(theGrid);
			theGrid.CaptureMouse();
			// Initial placement of the drag selection box.			
			Canvas.SetLeft(selectionBox, mouseDownPos.X);
			Canvas.SetTop(selectionBox, mouseDownPos.Y);
			selectionBox.Width = 0;
			selectionBox.Height = 0;
			
			// Make the drag selection box visible.
			selectionBox.Visibility = Visibility.Visible;
		}
		private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
		{
			// Release the mouse capture and stop tracking it.
			mouseDown = false;
			theGrid.ReleaseMouseCapture();
			
			// Hide the drag selection box.
			selectionBox.Visibility = Visibility.Collapsed;
			
			Point mouseUpPos = e.GetPosition(theGrid);
			
			// TODO: 
			//
			// The mouse has been released, check to see if any of the items 
			// in the other canvas are contained with mouseDownPos and 
			// mouseUpPos, for any that are, select them!
			//
		}
		private void Grid_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				// When the mouse is held down, reposition the drag selection box.
				
				Point mousePos = e.GetPosition(theGrid);
				if (mouseDownPos.X < mousePos.X)
				{
					Canvas.SetLeft(selectionBox, mouseDownPos.X);
					selectionBox.Width = mousePos.X - mouseDownPos.X;
				}
				else
				{
					Canvas.SetLeft(selectionBox, mousePos.X);
					selectionBox.Width = mouseDownPos.X - mousePos.X;
				}
				if (mouseDownPos.Y < mousePos.Y)
				{
					Canvas.SetTop(selectionBox, mouseDownPos.Y);
					selectionBox.Height = mousePos.Y - mouseDownPos.Y;
				}
				else
				{
					Canvas.SetTop(selectionBox, mousePos.Y);
					selectionBox.Height = mouseDownPos.Y - mousePos.Y;
				}
			}
		}
	}
