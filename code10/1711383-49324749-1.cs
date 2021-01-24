    public class PictureBoxEx : PictureBox
    {
        protected override void OnMouseHover(EventArgs e)
        {
            var args = new PictureBoxEventArgs((Left - 100) / 50, (-100) / 50);
            base.OnMouseHover(args);
        }
    }
