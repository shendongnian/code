    public MainViewModel()
    {
        // Load Essay Types
        EssayTypeRepository essayTypeRepository = new EssayTypeRepository();
        var essayTypes = essayTypeRepository.GetEssayTypes();
        var essayTypeViewModels = essayTypes.Select(m =>
        {
            var vm = EssayTypeViewModel()
            {
                Text = m.Text
            };
            vm.PropertyChanged += OnPropertyChanged;
            return vm;
        });
        EssayTypes = new ObservableCollection<EssayTypeViewModel>(essayTypeViewModels);
    }
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Checked")
            OnPropertyChanged("SelectedItems");
    }
    public string SelectedItems => string.Join(",", EssayTypes.Where(x => x.Checked).ToArray());
