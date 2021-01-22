    private readonly HashSet<ProgramViewModel> changedPrograms = new HashSet<ProgramViewModel>();
    void Cur_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {  
        changedPrograms.Add((ProgramViewModel)sender);
    }
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        foreach (ProgramViewModel model in changedPrograms)
        {
            ...
        }
    }
