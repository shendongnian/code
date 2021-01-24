    public class NativeListView : ListView
        {
            public static readonly BindableProperty
                IsScrollingProperty =
                    BindableProperty.Create(nameof(IsScrolling),
                    typeof(bool), typeof(NativeListView), false);
    
            public bool IsScrolling
            {
                get { return (bool)GetValue(IsScrollingProperty); }
                set { SetValue(IsScrollingProperty, value); }
            }
        }
