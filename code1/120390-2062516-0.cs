    int age;
    bool result = Int32.TryParse(txtAge.Text, out age);
    if (result)
    {
        // Parse succeeded and get the result in age
    }
    else
    {
        // Parse failed
    }
