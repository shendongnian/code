    if (c.IsChecked == true)
            {
                SelectedCourses = new ObservableCollection<Cours>();
    
                foreach(var item in Courses)
                {
                    if(item.IsChecked)//here IsChecked is true
                    {
                        SelectedCourses.Add(item);//here I have only one course  
                    }
                    SelectedCourses.ToList();
                }
            }
