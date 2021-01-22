    print("        #region Private Members
        private ContextMenuStrip listboxContextMenu;
        #endregion
        private void Form1_Load( object sender, EventArgs e )
        {
            //assign a contextmenustrip
            listboxContextMenu = new ContextMenuStrip();
            listboxContextMenu.Opening +=new CancelEventHandler(listboxContextMenu_Opening);
            listBox1.ContextMenuStrip = listboxContextMenu;
            //load a listbox
            for ( int i = 0; i < 100; i++ )
            {
                listBox1.Items.Add( "Item: " + i );
            }
        }
        private void listBox1_MouseDown( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                //select the item under the mouse pointer
                listBox1.SelectedIndex = listBox1.IndexFromPoint( e.Location );
                if ( listBox1.SelectedIndex != -1)
                {
                    listboxContextMenu.Show();   
                }                
            }
        }
        private void listboxContextMenu_Opening( object sender, CancelEventArgs e )
        {
            //clear the menu and add custom items
            listboxContextMenu.Items.Clear();
            listboxContextMenu.Items.Add( string.Format( "Edit - {0}", listBox1.SelectedItem.ToString() ) );
        } ");
