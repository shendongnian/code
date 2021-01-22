        //before using the ObservableCollection instantiate it.
        ItemsCollection= new ObservableCollection<ClassItem>();
        //Then build up your data however you need to.
        var resultData = GetData();
        //Update the ObservableCollection property which will send notification
        foreach (var classItem in resultData)
        {
            ItemsCollection.Add(classItem);
        }
