    public partial class Calendar : Grid
    {...
    
        public delegate void OnDayClickedDelegate(DateTime dateOfClickedDay);
        public event OnDayClickedDelegate OnDayClicked;
    ...
            private void DayClick(DateTime clickedDate)
        {
            OnDayClicked(clickedDate);
        }
    ...
    private void SomeVoid()
    {...
     DayLayout eventInDay = dayLayoutList[dayID];
                    var eventLabel = new Label
                    {
                        BackgroundColor = color,
                        Text = name.ToUpper(),
                        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    };
                    eventInDay.Children.Add(eventLabel);
    ...}
