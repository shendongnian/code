        private void DragOver(object sender, System.Windows.Forms.DragEventArgs e) 
        {
            if (!e.Data.GetDataPresent(typeof(System.String))) {
                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }
