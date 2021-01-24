    private void TargetTextBox_DragEnter(object sender, Windows.UI.Xaml.DragEventArgs e)
    {
        /// Change the background of the target
        VisualStateManager.GoToState(this, "Inside", true);
        bool hasText = e.DataView.Contains(StandardDataFormats.Text);
        e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
        if (hasText)
        {
            e.DragUIOverride.Caption = "Drop here to insert text";
            // Now customize the content
            if ((bool)HideRB.IsChecked)
            {
                e.DragUIOverride.IsGlyphVisible = false;
                e.DragUIOverride.IsContentVisible = false;
            }
            else if ((bool)CustomRB.IsChecked)
            {
                var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/dropcursor.png", UriKind.RelativeOrAbsolute));
                // Anchor will define how to position the image relative to the pointer
                Point anchor = new Point(0,52); // lower left corner of the image
                e.DragUIOverride.SetContentFromBitmapImage(bitmap, anchor);
                e.DragUIOverride.IsGlyphVisible = false;
                e.DragUIOverride.IsCaptionVisible = false;
            }
            // else keep the DragUI Content set by the source
        }
    }
