    public ICommand ClearSelection
    {
        get
        {
            return _clearSelection ?? new RelayCommand((x) =>
            {
                IList coll = (IList) x;
                foreach (var obj in coll)
                {
                    ((MammalViewModel)obj).Checked = false;
                }
            });
        }
    }
