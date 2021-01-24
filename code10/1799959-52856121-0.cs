    /// <inheritdoc cref="INotifyPropertyChanged"/>
    public partial class YourViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies that a properties value has changed.
        /// </summary>
        /// <param name="propertyName">The property that has changed.</param>
        public virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.CheckForPropertyErrors();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
