    static class FormUtil
    {
        static public void showForm(Form sender, Control reciever)
        {
            sender.ControlBox = false;
            sender.FormBorderStyle = FormBorderStyle.None;
            sender.ShowInTaskbar = false;
            sender.TopLevel = false;
            sender.Visible = true;
            sender.Dock = DockStyle.Fill;
            reciever.Controls.Clear(); //clear panel first
            reciever.Controls.Add(sender);
        }
    }
