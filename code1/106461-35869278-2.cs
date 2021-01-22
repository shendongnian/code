    private int fireCount = 0;
    private void inputFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
           fireCount++;
           if (fireCount == 1)
            {
                MessageBox.Show("Fired only once!!");
                dowork();
            }
            else
            {
                fireCount = 0;
            }
        }
    }
