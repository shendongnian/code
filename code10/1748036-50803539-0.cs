    class Folder
    {
        public  List<File> AssociatedFiles { get; set; }
    }
    
    class File
    {
        public Folder ParentFolder {get; set;}
        //create a constructor that takes the folder as a parameter
        public class File(Folder myFolder) {this.ParentFolder = myFolder;}
        void Update()
        {
            this.ParentFolder.AssociatedFiles.Add()
        }
    }
