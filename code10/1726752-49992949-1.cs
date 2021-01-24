    // Here I am binding using Prism.Commands.DelegateCommand
    public ICommand GotFocusCommand {get; private set;} = new Prism.Commands.DelegateCommand<int?>(GotFocus_Execute);
    private void GotFocus_Execute(int? index)
    {
       if(index != null)
          SelectedIndex = index.Value;
    }
