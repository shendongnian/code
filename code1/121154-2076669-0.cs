    public static class FormExtensions
    {
        public static void CenterForm(this Form theForm)
        {
            theForm.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width / 2 - theForm.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2 - theForm.Height / 2);
        }
    }
