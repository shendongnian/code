    // Add handlers...
    if (something)
    {
        c.Click += DoesSomething;
    }
    else
    {
        c.Click += DoesSomethingElse;
    }
    // Remove handlers...
    c.Click -= DoesSomething;
    c.Click -= DoesSomethingElse;
