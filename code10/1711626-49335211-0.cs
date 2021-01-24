    public class MyLabel : Label
    {
        public MyLabel()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                Style = Device.Styles.ListItemDetailTextStyle;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                Style = Device.Styles.ListItemTextStyle;
            }
        }
    }
