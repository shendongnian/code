      public partial class UserControl1 : UserControl {
        public UserControl1() {
          InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e) {
          if (e.Button == MouseButtons.Left) this.Capture = true;
          base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e) {
          if (e.Button == MouseButtons.Left) {
            // Your dragging logic here...
            Console.WriteLine(e.Location);
          }
          base.OnMouseMove(e);
        }
      }
