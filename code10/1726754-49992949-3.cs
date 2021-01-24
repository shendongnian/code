    public ICommand InsertCommand { get; private set; } = new Prism.Commands.DelegateCommand(InsertCommand_Execute);
    private void InsertCommand_Execute()
    {
       if (SelectedIndex > 0)
       {
          // Insert at the selected index. Note that the Ctrl inserted is just for example
          ListControls.Insert(SelectedIndex,
             new Ctrl()
             {
                RGN_Index = ++last_index, // or whatever
                RGN = $"RGN{last_index}", // or whatever
                RSN = $"RSN{last_index}", // or whatever
                SGN = $"SGN{last_index}", // or whatever
                SN = $"SN{last_index}" // or whatever
             });
       }
    }
    private int last_index = 2; // this is just example. You might not even need this.
