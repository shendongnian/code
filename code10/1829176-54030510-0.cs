    private void OnOpenWineDetailView(int wineId)
    {
        _wine = ApiHelper.GetApiResult<Wine>($"{ _baseUri}/{wineId}");
        OnPropertyChanged(nameof(WineFull));
    }
