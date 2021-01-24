    public void GetData()
    {
        this.Items = this.RefreshData(this.ItemService.GetAll(this.SelectedCategory));
        if (this.FromDashboard)
            this.Items = this.Items.Where(x => x.Status != "Complete").ToObservableCollection();
        OnPropertyChanged(nameof(this.Items));
    }
