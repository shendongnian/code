    using System.Reflection;
    ...
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e) {
          if (e.Button == MouseButtons.Left) {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(notifyIcon1, null);
          }
        }
 
