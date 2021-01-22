        private void Library_AlbumAdded(object sender, AlbumInfoEventArgs e)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate { AddToGrid(e.AlbumInfo); });
            }
            else
            {
                AddToGrid(e.AlbumInfo);
            }
        }
        private void Library_Finished(object sender, EventArgs e)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate { FinalUpdate(); });
            }
            else
            {
                FinalUpdate();
            }
        }
