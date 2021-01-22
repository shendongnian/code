    // correct way using lambda
    button.Click += (sender, eventArgs) => MessageBox.Show("Clicked!");
    // compile error - wrong number of arguments
    button.Click += () => MessageBox.Show("Clicked!");
    // anon method, omitting arguments, works fine
    button.Click += delegate { MessageBox.Show("Clicked!"); };
