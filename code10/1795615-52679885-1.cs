    Content.SomeEvent -= Content_SomeEvent; // Unhook event handlers.
    Controls.Remove(Content);
    Content.Dispose();
    Controls.Remove(Header);
    Header.Dispose();
