        private void button1_Click( object sender, EventArgs e )
        {
            foreach (string item in listBox1.SelectedItems)
            {
                string[] values = item.ToString().Split('-');                
                MessageBox.Show( values[0] );
                MessageBox.Show( values[1] );
            }
        }
