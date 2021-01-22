    foreach (Test test in tests)
    {
        // Take a copy of the "test" variable so that each iteration
        // creates a delegate capturing a different variable (and hence a
        // different value)
        Test copy = test;
        Button button = new Button();
        button.Text = test.name;
        button.Click += (obj, arg) => CreateTest(copy);
        this.flowLayoutPanel1.Controls.Add(button);
    }
