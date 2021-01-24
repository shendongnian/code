    public class CustomEntry : Entry
    {
        public static readonly BindableProperty ActiveHintTextColorProperty = BindableProperty.Create(nameof(ActiveHintTextColor),
           typeof(Color),
           typeof(CustomEntry),
           Color.Accent);
        /// <summary>
        /// ActiveHintTextColor summary. This is a bindable property.
        /// </summary>
        public Color ActiveHintTextColor
        {
            get { return (Color)GetValue(ActiveHintTextColorProperty); }
            set { SetValue(ActiveHintTextColorProperty, value); }
        }
    }
