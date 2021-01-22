       public class CustomDatePicker : DatePicker
        {
            protected override void OnPreviewKeyDown(KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    this.TryTransformDate();
                }
    
                base.OnPreviewKeyDown(e);
            }
    
            protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
            {
                this.TryTransformDate();
                base.OnPreviewLostKeyboardFocus(e);
            }
            protected void TryTransformDate()
            {
                DateTime tryDate;
                if (DateHelper.TryParseDate(this.Text, out tryDate))
                {
                    switch (this.SelectedDateFormat)
                    {
                        case DatePickerFormat.Short: 
                            {
                                this.Text = tryDate.ToShortDateString();
                                break;
                            }
    
                        case DatePickerFormat.Long: 
                            {
                                this.Text = tryDate.ToLongDateString();
                                break;
                            }
                    }
                }
    
            }
        }
