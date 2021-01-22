    SomeMenuCommand = new RelayCommand(
            Actions.Empty,
            x => CanSomeMenuCommandExecute());
    // Another example:
    var lOrderedStrings = GetCollectionOfStrings().OrderBy(Functions.Identity);
