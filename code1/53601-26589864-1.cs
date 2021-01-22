    namespace UI {
      public class PlaceholderTextBox : TextBox {
        public String Value { get; set; }
        public String PlaceholderText { get; set; }
        public Brush PlaceholderBrush { get; set; }
        private Brush ValuedBrush { get; set; }
    
        public PlaceholderTextBox() : base() {}
    
        protected override void OnInitialized(EventArgs e) {
          base.OnInitialized(e);
    
          ValuedBrush = this.Foreground;
    
          if (String.IsNullOrEmpty(this.Text)) {
            this.Text = PlaceholderText;
            this.Foreground = PlaceholderBrush;
          }
        }
    
        protected override void OnGotFocus(System.Windows.RoutedEventArgs e) {
          this.Foreground = ValuedBrush;
          if (String.IsNullOrEmpty(Value)) {
            this.Text = "";
          }
    
          base.OnGotFocus(e);
        }
    
        protected override void OnLostFocus(System.Windows.RoutedEventArgs e) {
          Value = this.Text;
          if (String.IsNullOrEmpty(this.Text)) {
            this.Text = PlaceholderText;
            this.Foreground = PlaceholderBrush;
          }
    
          base.OnLostFocus(e);
        }
      }
    }
