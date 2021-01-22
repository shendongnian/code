    // On inital page load for data entry store a key.
    // This is a basic example, you should have a session wrapper
    Session["Unsaved"] = 1;
    
    // When you do the save logic make sure you check this session variable and save if
    // it still exists.
    if (Session["Unsaved"] != null)
    {
      // Save data here
      Session.Remove("Unsaved");
    }
    else
    {
      // Show message that save has already completed or session has expired.
    }
