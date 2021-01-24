     public ICommand ClearSelection
            {
                get
                {
                    return _clearSelection ?? new RelayCommand((x) =>
                    {
                        switch (x)
                        {
                            case ObservableCollection<GiraffeViewModel> giraffes:
                                DeCheckElements(giraffes);
                                break;
                            case ObservableCollection<ElephantViewModel> elephants:
                                DeCheckElements(elephants);
                                break;
                        }
                    });
                }
            }
