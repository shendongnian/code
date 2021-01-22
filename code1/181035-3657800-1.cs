    public static IObservable<IEvent<TextChangedEventArgs>> GetTextChanged(
        this TextBox tb)
    {
        return Observable.FromEvent<TextChangedEventArgs>(
                   h => textBox1.TextChanged += h, 
                   h => textBox1.TextChanged -= h
               )
               .DistinctUntilChanged(t => t.Text);
    }
