    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
            : base()
        {
            DataObject.AddPastingHandler(this, new DataObjectPastingEventHandler(CheckPasteFormat));
        }
        private Boolean CheckFormat(string text)
        {
            short val;
            return Int16.TryParse(text, out val);
        }
        private void CheckPasteFormat(object sender, DataObjectPastingEventArgs e)
        {
            var isText = e.SourceDataObject.GetDataPresent(System.Windows.DataFormats.Text, true);
            if (isText)
            {
                var text = e.SourceDataObject.GetData(DataFormats.Text) as string;
                if (CheckFormat(text))
                {
                    return;
                }
            }
            e.CancelCommand();
        }
        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!CheckFormat(e.Text))
            {
                e.Handled = true;
            }
            else
            {
                base.OnPreviewTextInput(e);
            }
        }
    }
