    private void MyUserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        MyUserControlViewModel vm = DataContext as MyUserControlViewModel; //Get the ViewModel from the View's DataContext
        
        if(vm == null)
            return;
        vm.ThisIsCalledEvent = delegate () { ThisIsCalled(); }; //When the action is invoked, call the desired function
    }
