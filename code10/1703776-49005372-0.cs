        public class Shadow : BindableObject /* It's explictly bindable */
        {
            #region Properties
            public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(Shadow), Color.Black);
            public Color ShadowColor
            {
                get { return (Color)GetValue(ShadowColorProperty); }
                set { SetValue(ShadowColorProperty, value);
                    //Notify the ShadowColorProperty Changed
                    OnPropertyChanged();
                }
            }
           ...
        }
