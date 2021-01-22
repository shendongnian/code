    class TimeTextBox : TextBox
    {
        public Boolean IsProperTime { get; set; }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            DateTime time;
            if (String.IsNullOrEmpty(Text) || !DateTime.TryParse(Text, out time))
            {
                IsProperTime = false;
            }
            else
            {
                IsProperTime = true;
            }
            UpdateVisual();
            base.OnTextChanged(e);
        }
        private void UpdateVisual()
        {
            if (!IsProperTime)
            {
                BorderBrush = Brushes.Red;
                BorderThickness = new Thickness(1);
            }
            else
            {
                ClearValue(BorderBrushProperty);
                ClearValue(BorderThicknessProperty);
            }
        }
    }
