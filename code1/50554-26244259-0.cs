    internal class FixedComboBox : ComboBox
    {
        protected override void OnResize(EventArgs e)
        {
            if (IsHandleCreated && !Focused)
            {
                BeginInvoke((Action)(() =>
                    {
                        SelectionLength = 0;
                    }));
            }
            base.OnResize(e);
        }
    }
