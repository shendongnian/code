    var list = new[]
    {
        new Team { Id = 1, Name = "One" },
        new Team { Id = 2, Name = "Two" },
        new Team { Id = 3, Name = "Three" }
    };
    combobox.ValueMember = "Id"; // Name of property to represent a Value
    combobox.DisplayMember = "Name"; // Name of property to represent displayed text.
    combobox.DataSource = list; // Bind all items to the control
