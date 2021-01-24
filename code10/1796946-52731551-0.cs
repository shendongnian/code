    FirebaseDatabase.DefaultInstance
        .GetReference("users").OrderByChild("username").EqualTo(searchusername)
        .ValueChanged += HandleValueChanged;
    }
    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }
      // Do something with the data in args.Snapshot
    }
