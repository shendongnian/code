    public class MyDateTimePicker : DateTimePicker
    {
        // ... some stuff
        protected override void OnValueChanged(EventArgs eventargs)
        {
            System.Diagnostics.Debug.Write("Clicked -  ");
            System.Diagnostics.Debug.WriteLine(this.Value);
            base.OnValueChanged(eventargs);
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            System.Diagnostics.Debug.Write("Closed -  ");
            System.Diagnostics.Debug.WriteLine(this.Value);
            base.OnCloseUp(eventargs);
        }
        // some more stuff ...
    }
