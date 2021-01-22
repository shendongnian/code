    private delegate void UpdateLabelDelegate(DependencyProperty dp, object value);
    
    public void UpdateLabelContent(Label label, string newContent)
    {
        Dispatcher.Invoke(new UpdateLabelDelegate(label.SetValue), DispatcherPriority.Background, ContentProperty, newContent);
    }
