            private class DayLayout : StackLayout
        {
            public delegate void OnClickedDelegate(DateTime dateOfClickedDay);
            public event OnClickedDelegate OnClicked;
            public Label DayNumber;
            public DayLayout(DateTime day)
            {
                GestureRecognizers.Add
                (
                    new TapGestureRecognizer
                    {
                        Command = new Command(() => OnClicked(day))
                    }
                );
                var dayNumber = new Label
                {
                    HorizontalTextAlignment = TextAlignment.End,
                    VerticalTextAlignment = TextAlignment.Start,
                    Text = day.ToString("dd"),
                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                    FontAttributes = FontAttributes.Bold
                };
                DayNumber = dayNumber;
                this.Children.Add(DayNumber);
            }
        }
