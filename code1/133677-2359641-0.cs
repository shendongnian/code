    private bool messageBoxIsOpen;
    void filOvervakare_Changed(object sender, FileSystemEventArgs e)
    {
        if (this.messageBoxIsOpen)
        {
            return;
        }
        this.messageBoxIsOpen = true;
        if (MessageBox.Show(
            "Vill du ladda upp filen " + e.Name + "?", 
            "En fil har ändrats", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question) == DialogResult.Yes)
        {
           //code code code           
        }
        this.messageBoxIsOpen = false;
    }
