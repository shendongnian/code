    public class Job : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged; 
        public StateEnum State {
            get { return this.state; }
            private set {
                this.state = value;
                this.OnPropertyChanged();
            }
        }
    }
    public class MainWindow : Window, INotifyPropertyChanged 
        public List<Job> Jobs {
            get { return this.jobs; }
            private set {
                this.jobs = value;
                
                foreach(var job in this.jobs)
                {
                    job.PropertyChanged += job_PropertyChanged;
                }
            }
        }
        private void job_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged("Jobs");
        }
    }
