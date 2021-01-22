    partial class Form2 : Form {
        public static Form2 Instance { get; private set; }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Instance = this;
        }
        
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Instance = null;
        }
