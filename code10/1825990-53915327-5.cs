    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Event when property changed.
        /// </summary>
        /// <param name="s">string</param>
        protected void OnPropertyChanged([CallerMemberName] string member = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));
        }
    }
