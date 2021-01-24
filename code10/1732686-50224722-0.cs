        private async void TaskPageHeader_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TaskNoBox.DataContext = new object();
            TaskNoBox.DataContext = CurrentTask;
        }
