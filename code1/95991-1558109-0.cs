    Public InputQueue<InputEvent> = new Queue<InputEvent>();
    
    // An input event handler.
    private void btnDoSomething_Click(object sender, EventArgs e)
    { 
        lock(InputQueue)
        {
             InputQueue.Enqueue(new DoSomethingInputEvent());
        }
    }
    // Your render method (executing in a background thread). 
    private void RenderNextFrame()
    {
        Queue<InputEvent> inputEvents = new Queue<InputEvent>();
        lock(InputQueue)
        {
             inputEvents.Enqueue(InputQueue.Dequeue());
        }
        // Process your input events from the local inputEvents queue.
        ....
        // Now do your render based on those events.
        ....
    }
