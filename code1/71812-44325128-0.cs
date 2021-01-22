    /// <summary>
    /// Represents a <see cref="TextBox"/> control that does not allow drag on its contents.
    /// </summary>
    public class NoDragTextBox:TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoDragTextBox"/> class.
        /// </summary>
        public NoDragTextBox()
        {
            DataObject.AddCopyingHandler(this, NoDragCopyingHandler);
        }
        private void NoDragCopyingHandler(object sender, DataObjectCopyingEventArgs e)
        {
            if (e.IsDragDrop)
            {
                e.CancelCommand();
            }
        }
    }
