       textBox1.CharacterCasing = CharacterCasing.Upper; 
       ...
       private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Path.GetInvalidFileNameChars().Contains(e.KeyChar) ||
                Path.GetInvalidPathChars().Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
