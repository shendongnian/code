        BindingSource bs = new BindingSource();
        bs.DataSource = yourList;
        bs.AddingNew += delegate(object sender, AddingNewEventArgs args)
        {
            args.NewObject = new SomeType(args);
        };
        grid.DataSource = bs;
