     public void CheckVal()
       {
     SelectedCourses = new ObservableCollection<Cours>();
                    foreach (var item in Courses)
                    {
                        if (item.IsChecked)
                        {
                            SelectedCourses.Add(item);
                        }
    }
