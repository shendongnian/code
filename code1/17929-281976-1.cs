    public struct FolderData {
        public static FolderData Empty = new FolderData();
        
        public string FolderName {get; set;}
        public int FilesInFolder {get; set;}
    }
    
    public FolderData GetFolderData(){
        if(this.ShowDialog() == DialogResult.OK) {
            return new FolderData {
                FolderName = this.FolderName.Text;
                FilesInFolder = int.Parse(this.FilesInFolder.Text);
            }
        }
        return FolderData.Empty;
    }
