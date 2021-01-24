    var handled = false;
    
    GestureDetector _gestureDetector = new GestureDetector(this, new GestureListener());
    
    _gestureDetector.DoubleTap += (object sender, GestureDetector.DoubleTapEventArgs e) => {
    	handled = true;
    };
    
    webView.Touch += (object sender, View.TouchEventArgs e) => {
    	_gestureDetector.OnTouchEvent(e.Event);
    	if (e.Event.Action == MotionEventActions.Up)
    	{
    		handled = false;
    	}
    	e.Handled = handled;
    };
