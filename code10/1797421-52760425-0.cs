    ...
    ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
    ...
    public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
    ...
    private async Task ShowInitialViewModels()
    {
        var tasks = new List<Task>();
        tasks.Add(Mvx.Resolve<IMvxNavigationService>().Navigate<FragmentTab1ViewModel>());
        tasks.Add(Mvx.Resolve<IMvxNavigationService>().Navigate<FragmentTab2ViewModel>());
        await Task.WhenAll(tasks);
    }
