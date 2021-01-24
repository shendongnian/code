    public PinchToZoomContainer()
    {
         var pinchGesture = new PinchGestureRecognizer();
         pinchGesture.PinchUpdated += OnPinchUpdated;
         bigImg.GestureRecognizers.Add(pinchGesture);
    }
