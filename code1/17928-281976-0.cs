    public string GetFolderName(){
        if(this.ShowDialog() == DialogResult.OK) {
            return this.FolderName.Text;
        }
        return String.Empty;
    }
