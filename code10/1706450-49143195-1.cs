        public partial class Form1 : Form
        {
        private Hector.Framework.Utils.Drag drag = new Hector.Framework.Utils.Drag();
        
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
           drag.Grab(pictureBox);
        }
        
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
           drag.Release();
        }
        
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
           drag.MoveObject();
        }
        }
