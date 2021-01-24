    public class MyViewModel
    {
        private SettingsPage settingsPage = new ...;
        public int Id { get; set; }
        public string Name { get; set; }
        public MyViewModel()
        {
            OpenPageCmd =
                new RelayCommand<MyViewModel>(this, vm => settingsPage.OpenPage(vm.Id, vm.Name));
        }
        public ICommand OpenPageCmd { get; }
    }
