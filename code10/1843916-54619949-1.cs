    public class MyDateTimePicker : DateTimePicker
    {
        protected override string GetValueForTextBox()
        {
            return SelectedDate?.ToString("yyyy-MM-dd HH:mm Z");
        }
    }
