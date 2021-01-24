    public class XamlConsts
    {
        public readonly Thickness TileStartDatePadding = new Thickness(0);
        public readonly GridLength TileSeparatorHeight = new GridLength(0);
        public StackOrientation CrossPlatformStackOrientation
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        return StackOrientation.Horizontal;
                    case Device.iOS:
                        return StackOrientation.Vertical;
                    default: return StackOrientation.Horizontal;
                }
            }
        }
