    this.Dispatcher.BeginInvoke(new Action( ()=>{
        // MoveFocus takes a TraversalRequest as its argument.
        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
        // Gets the element with keyboard focus.
        UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
        // Change keyboard focus.
        if (elementWithFocus != null)
        {
            elementWithFocus.MoveFocus(request);
        }
    }), DispatcherPriority.ApplicationIdle);
