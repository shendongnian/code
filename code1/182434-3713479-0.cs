        private void listView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<CustomClass> newList = e.NewValue as List<CustomClass>;
            if (newList != null && (sender as ListView).Tag != null)
            {
                foreach (CustomClass cClass in newList)
                    if (cClass.Equals((sender as ListView).Tag as CustomClass))
                        (sender as ListView).SelectedItem = cClass;
            }
        }
