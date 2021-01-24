    public void SeekBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
    	// Only process event if click is not on thumb.
    	Thumb Obj = GetSliderThumb(sender as Slider);
    	Point Pos = e.GetPosition(Obj);
    	if (Pos.X < 0 || Pos.Y < 0 || Pos.X > Obj.ActualWidth || Pos.Y > Obj.ActualHeight) {
    		// Immediate seek when clicking elsewhere.
    	}
    }
    
    public Thumb GetSliderThumb(Slider obj) {
    	var track = obj.Template.FindName("PART_Track", obj) as Track;
    	return track?.Thumb;
    }
