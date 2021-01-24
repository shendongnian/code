    public class MyViewModel
    {
        public int Id {get; set; }
        public string Name {get; set; }
        
        public ICommand OpenPageCmd { get; } =
            new Command<MyViewModel>(this, vm => settingsPage.OpenPage(vm.Id, vm.Name));
    }
