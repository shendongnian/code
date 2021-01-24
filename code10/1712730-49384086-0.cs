      class CustomNumericUpDown : NumericUpDown
      {
        protected override void OnValueChanged(EventArgs e)
        {
            if (QueryCancelValueChanging != null && QueryCancelValueChanging())
                return;
            else
            {
                EventArgs args = (EventArgs)e;
                base.OnValueChanged(args);
            }
        }
        public event Func<bool> QueryCancelValueChanging;
    }
