		private ObservableCollection<Task> _tasks;
        //Tasks will store all of the tasks of type Task that we add to it 
        //as well as be bound to our ListView that will display whatever we add to our Tasks
		public ObservableCollection<Task> Tasks
		{
			get
			{
				return _tasks;
			}
			set
			{
				if (value != _tasks)
				{
					_tasks = value;
					OnPropertyChanged("Tasks");
				}
			}
		}
        //Here we implement OnPropertyChanged so our ObservableCollection can be notified 
        //whenever we have a new task added to or removed from Tasks (this is created when we implement INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}
        //Create a new Task and add it to our Tasks any time the addTask button is clicked
		private void addTask(object sender, RoutedEventArgs e)
		{
			Tasks.Add(new Task(input.Text));
		}
