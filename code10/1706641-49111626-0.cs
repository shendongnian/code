    private void ShowMethod()
    {
        AddMemberViewModel vm = App.container.Resolve<AddMemberViewModel>();
        vm.Member = new Member(); // Replace here with your Member object you want 
                                  // to edit
        var child = new AddMemberView
        {
            DataContext = vm
        };
        child.ShowDialog();
    }
