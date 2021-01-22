    int? enteredValue = null;
    if(!string.IsNullOrEmpty(textNumberEntry.Text))
    {
        int temp = 0;
        if(int.TryParse(textNumberEntry.Text, out temp))
           enteredValue = temp;
    }
    // Call proc with enteredValue, check enteredValue.HasValue first though!
