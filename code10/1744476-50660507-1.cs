    public class SomeViewModel
    {
         public SomeViewModel(IFileOpenService fileOpen)
         {
             this._fileOpen = fileOpen; 
         }
         public void FileOpenCommandExecute
         {
             if (this._fileOpen.OpenFile())
             {
                 var selectedFiles = this._fileOpen.FileNames;
                 // .. do something with the selected files...
             }
         }
    }
