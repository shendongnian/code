    public sealed class PropertyProgress<T> : IProgress<T>, INotifyPropertyChanged
    {
          public PropertyProgress(T initialProgress = default(T));
        
          public T Progress { get; }
        
          public event PropertyChangedEventHandler PropertyChanged;
    }
