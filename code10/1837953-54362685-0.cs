    private bool _isProcessing = false;
    private readonly Queue<PointerPoint> _operationQueue = new Queue<PointerPoint>();
    
    private async Task EnqueueOperationAsync(PointerPoint point)
    {
        //using the pointer point as argument of my operation in this example
        _operationQueue.Enqueue(point); 
        if (!_isProcessing)
        {
            _isProcessing = true;
            while (_operationQueue.Count != 0)
            {
                var argument = _operationQueue.Dequeue();
                await MyOperationAsync(argument);
            }
            _isProcessing = false;
        }
    }
    private async void UIElement_OnPointerMoved(object sender, PointerRoutedEventArgs e)
    {
        await EnqueueOperationAsync(e.GetCurrentPoint(this));
    }
