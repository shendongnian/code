    var lastClickedOn = ...; // The time from the database.
    var now = DateTime.Now;
    // Check if the click time is more than, or exactly, 24 hours ago.
    if (lastClickedOn <= now.AddHours(-24))
    {
        // Show/enable the button
    }
