        /// <summary>
        /// onPreviewKeyDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
        /// <summary>
        /// onKeyDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Input.SetFlag(e.KeyCode);
            e.Handled = true;
        }
        
        /// <summary>
        /// onKeyUp
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            Input.RemoveFlag(e.KeyCode);
            e.Handled = true;
        }
