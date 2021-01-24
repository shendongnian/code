    using Plugin.Clipboard;
    private void I_Tapping(object sender, MR.Gestures.LongPressEventArgs e)
    {
        CrossClipboard.Current.SetText(editorLinkText.Text);
    }
