    public class UploadProgressViewModel : INotifyPropertyChanged, IProgress<int> {
        public int Percentage {
            get {
                //...return value
            }
            set {
                //...set value and notify change
            }
        }
        public void Report(int value) {
            Percentage = value;
        }
    }
    
