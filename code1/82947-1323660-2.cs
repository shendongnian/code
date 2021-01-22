        private void tabControl1_Selecting( object sender, TabControlCancelEventArgs e )
        {
            int badIndex = 0;
            if ( tabControl1.SelectedIndex == badIndex )
                e.Cancel = true;            
        }
