    Dispatcher.Invoke<Task>(async () => {
        waterfallFlow.Children.Clear();
        var parsedValues = doc.DocumentNode.SelectNodes(...)
            .Skip(1)
            .Select(r => {...})
            .ToList();
        foreach (var item in parsedValues) {
            await Task.Delay(200);
            waterfallFlow.Children.Add(item);
            waterfallFlow.Refresh();
        }
    }, DispatcherPriority.ContextIdle, null);
