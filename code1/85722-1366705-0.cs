    Int32 index = 0;
    while (index < Application.OpenForms.Count)
    {
        try
        {
            // Try to copy the form because the index may be or may
            // become invalid.
            Form form = Application.OpenForms[index];
            // Do stuff with the form.
        }
        catch (ArgumentOutOfRangeException exception)
        {
            // Handle no longer valid index.
        }
        index++;
    }
