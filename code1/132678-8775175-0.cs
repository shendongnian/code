    Ourself.Rename();
    // Download or copy new version
    File.Copy(newVersion, Ourself.FileName());
    // Launch new version
    System.Diagnostics.Process.Start(Ourself.FileName());
    // Close current version
    Close(); // Exit();
