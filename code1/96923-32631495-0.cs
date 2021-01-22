        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            //code to create a watcher and allow it to reise events...
        }
        //watcher onCreate event
        public void onCreated(object sender, FileSystemEventArgs e)
        {
            if (!updateNotifications )
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append(e.FullPath);
                stringBuilder.Append(" ");
                stringBuilder.Append(e.ChangeType.ToString());
                stringBuilder.Append("    ");
                stringBuilder.Append(DateTime.Now.ToString());
                updateNotifications = true;
            }
        }
        //timer to check the flag every X time
        private void timer_Tick(object sender, EventArgs e)
        {
            if (updateNotifications )
            {
                notificationListBox.Items.Insert(0, stringBuilder.ToString());
                updateNotifications = false;
            }
        }
