        public void onCreated(object sender, FileSystemEventArgs e)
        {
            stringBuilder.Remove(0, stringBuilder.Length);
            stringBuilder.Append(e.FullPath);
            stringBuilder.Append(" ");
            stringBuilder.Append(e.ChangeType.ToString());
            stringBuilder.Append("    ");
            stringBuilder.Append(DateTime.Now.ToString());
            updateNotifications = true;
            Invoke((Action)(() => {notificationListBox.Items.Insert(0, stringBuilder.ToString());}));
        }
