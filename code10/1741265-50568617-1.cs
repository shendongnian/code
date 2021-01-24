    Task t = Task.Factory.StartNew(() =>
    {
        int i = 1;
        while (true)
        {
            // Note: this works because the thread slept 3000ms.
            // If the thread doesn't sleep, we should declare a new variable
            // so that i will not change when the action invokes.
            // That means `var content = i;`
            // Then `MyLabel.Dispatcher.InvokeAsync(() => MyLabel.Content = content);`
            MyLabel.Dispatcher.InvokeAsync(() => MyLabel.Content = i);
            Thread.Sleep(3000);
            i++;
        }
    });
