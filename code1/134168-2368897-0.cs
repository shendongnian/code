    public sealed class MyNumericUpDown : NumericUpDown {
    
        private bool suppress;
    
        protected override void OnValueChanged(EventArgs e) {
            if (!suppress) {
                base.OnValueChanged(e);
            }
        }
    
        public void SetRange(decimal min, decimal max) {
            suppress = true;
            try {
                Minimum = min;
                Maximum = max;
            }
            finally {
                suppress = false;
            }
        }
    
    }
