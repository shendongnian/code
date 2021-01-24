    public class MainContext : ApplicationContext
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        private Form1 form = null;
        public MainContext()
        {           
            notifyIcon.Text = "test";
            // whatever the icon
            notifyIcon.Icon = Properties.Resources.Folder;
            notifyIcon.Click += NotifyIcon_Click;
         
            // make the icon visible
            notifyIcon.Visible = true;
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // special case for the first click
            if (form == null)
            {
                form = new Form1();
                form.ShowDialog();
            }
            else
            {
                // test if the form has been recently closed. Here i consider 1/10
                // of a second as "recently" closed. So we want only to handle the click
                // if the time is greater than that.
                if ((DateTime.Now - form.LastDeactivate).TotalMilliseconds >= 100)
                {
                    // specially control the show hide as visibility on/off
                    // does not trigger the activate event that screw up the
                    // later hiding of the form
                    if (form.Visible)
                    {
                        form.Hide();
                    }
                    else
                    {
                        form.Show();
                        form.Activate();
                    }
                }
            }
        }      
    }
