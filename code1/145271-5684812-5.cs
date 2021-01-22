    private void EditorKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyData == (Keys)Shortcut.CtrlV)
        {
            mshtml.HTMLDocument document = ((mshtml.HTMLDocument)editorWebBrowser.Document);
            if (Clipboard.ContainsImage())
            {
                // Save image to user temp dir
                String imagePath = Path.GetTempPath() + "\\" + Path.GetRandomFileName() + ".jpg";
                Clipboard.GetImage().Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Insert image href in to html with temp path
                Uri uri = null;
                Uri.TryCreate(imagePath, UriKind.Absolute, out uri);
                document.execCommand("InsertImage", false, uri.ToString());
                // Fire event that image saved to any interested listeners who might want to save it elsewhere as well
                if (OnImageInserted != null)
                {
                    OnImageInserted(this, new ImageInsertEventArgs { HrefUrl = uri.ToString(), TempPath = imagePath, HtmlElementId = elementId.ToString() });
                }
            }
            else
            {
                // execute the default paste command
                document.execCommand("Paste", false, null);
            }
        }
    }
