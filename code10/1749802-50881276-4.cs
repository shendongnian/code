    public Zicker()
    {
        ObservableCollection<MyClass> vs = new ObservableCollection<MyClass>();
        for (int i = 0; i < 3; i++)
        {
            var test = new MyClass()
            {
                HeyName = heresamplenames[i],
                HeySurname = heresamplesurnames[i],
                HeyAge = heresampleages[i],
            };
            test.OnAgeChanged += Test_OnAgeChanged;
            vs.Add(test);
        }
    
        YourList = vs;
        YourList.CollectionChanged += WonCollectionChanged;
    }
    
    private void Test_OnAgeChanged(object sender, EventArgs e)
    {
        RaisePropertyChanged("BindMeLabel");
    }
