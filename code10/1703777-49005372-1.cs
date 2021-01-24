        public class MyBoxText : Label /* It's bindable by inheritance */
        {
         ...
            public static readonly BindableProperty GhostProperty = BindableProperty.Create(nameof(Ghost), typeof(Shadow), typeof(MyBoxText), null);
            public Shadow Ghost
            {
                get { return (Shadow)GetValue(GhostProperty); }
                set {
                    //register the ShadowColor change event
                    value.PropertyChanged += ShadowColor_PropertyChanged;
                    SetValue(GhostProperty, value); }
            }
            private void ShadowColor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                //unregister the event
                this.Ghost.PropertyChanged -= ShadowColor_PropertyChanged;
                //set this.Ghost to a new object with new ShadowColor to trigger the OnPropertyChanged
                this.Ghost = new Shadow
                {
                    ShadowColor = (sender as Shadow).ShadowColor,
                    ShadowRadius = Ghost.ShadowRadius
                };
            }
        }
