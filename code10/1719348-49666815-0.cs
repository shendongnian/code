         public void sndLinksSelection_Click(object sender, EventArgs e)
        {
            DR = DialogResult.OK;
            changeTextBox();
    
        }
        private void changeTextBox(){
    
     MyClass.SelectLinksM frmSelection =
            new MyClass.SelectLinksM(linkNames.ToArray());
            frmSelection.Show();
    
            DialogResult result = frmSelection.DiaRes;
    
            if (result == DialogResult.OK)
            {
                MessageBox.Show("I passed a value to the main class!");
            }
    
    }
