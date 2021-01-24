    private void ShowMethod()
    {
        IMemberRepository repo = App.container.Resolve<IMemberRepository>();
        
        // Replace 'new Member()' here with your Member object you want to edit
        AddMemberViewModel vm = new AddMemberViewModel(repo, new Member())
                                  
        var child = new AddMemberView
        {
            DataContext = vm
        };
        child.ShowDialog();
    }
