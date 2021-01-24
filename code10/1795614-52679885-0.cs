    Content.Visible = false;
    Content.SomeEvent -= Content_SomeEvent; // Unhook event handlers.
    Controls.Remove(Content);
    Content.Dispose();
    Header.Visible = false;
    Controls.Remove(Header);
    Header.Dispose();
