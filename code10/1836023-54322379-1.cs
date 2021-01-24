    public ICommand ClearSelection
    {
        get
        {
            return _clearSelection ?? new RelayCommand((x) =>
            {
                ObservableCollection<MammalViewModel> coll = ((IEnumerable)x).Cast<ObservableCollection<MammalViewModel>();
                foreach (var obj in coll)
                {
                    obj.Checked = false;
                }
            });
        }
    }
