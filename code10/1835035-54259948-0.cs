    namespace DirtyTextBox
    {
        public class DirtyNotifyingTextBox : TextBox
        {
            public DirtyNotifyingTextBox()
            {
                this.DefaultStyleKey = typeof(TextBox);
                DataContextChanged += DirtyNotifyingTextBox_DataContextChanged;
            }
    
            private void DirtyNotifyingTextBox_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                _originalValue = this.Text;
                TextChanged += DirtyNotifyingTextBox_TextChanged;
                SetToGreen();
            }
    
            private string _originalValue { get; set; }
    
            private void DirtyNotifyingTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (this.Text != _originalValue)
                {
                    SetToRed();
                }
                else
                {
                    SetToGreen();
                }
            }
    
            private void SetToGreen()
            {
                this.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 205, 0));
            }
    
            private void SetToRed()
            {
                this.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
            }
    
            public void Reset()
            {
                Reset(string.Empty);
            }
    
            public void Reset(string resetValue)
            {
                _originalValue = resetValue;
                this.Text = resetValue;
            }
    
            protected override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
            }
        }
    }
