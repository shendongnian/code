    string sanitized = Path.Combine(pathOnly, sanitizedFileName);
    if (!System.IO.File.Exists(sanitized))
    {
        // perform the move
        System.IO.File.Move(files2, sanitized);
    }
    else
    {
        // perform other action
    }
