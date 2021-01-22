    public class OneWayCheckBox : CheckBox
    {
        private class CancelTwoWayMetadata : FrameworkPropertyMetadata
        {
            protected override void Merge(PropertyMetadata baseMetadata,
                                          DependencyProperty dp)
            {
                base.Merge(baseMetadata, dp);
                BindsTwoWayByDefault = false;
            }
        }
        static OneWayCheckBox()
        {
            // Remove BindsTwoWayByDefault
            IsCheckedProperty.OverrideMetadata(typeof(OneWayCheckBox),
                                               new CancelTwoWayMetadata());
        }
        protected override void OnToggle()
        {
            // Do nothing.
        }
    }
