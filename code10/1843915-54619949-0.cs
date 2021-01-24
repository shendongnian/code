    public class MyDateTimePicker : DateTimePicker
    {
        protected override string GetValueForTextBox()
        {
            return SelectedDate?.ToString("yyyy-mm-dd HH:mm Z");
        }
    }
