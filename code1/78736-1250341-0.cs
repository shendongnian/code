    public class MyButton : System.Windows.Forms.Button {
        public MyButton()
            : base() {
            // No default implementation
        }
        protected override void OnMouseDown(Object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.PressedImage;
        }
        protected override void OnMouseEnter(Object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.HoveringImage;
        }
        protected override void OnMouseLeave(Object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.DefaultImage;
        }
    }
