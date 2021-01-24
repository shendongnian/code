    List<StorageFile> FileList = New List<StorageFile>();
    
    Microsoft.Toolkit.Uwp.UI.AdvancedCollectionView ObservableFileList
            {
                get; set;
            }
    
    
    
    
    void InitializeList(){
    
    //here we pass the backing list as an argument, 
    //any changes on the filelist will be directly reflected on our new observablelist, and vice versa
    
    ObservableFileList = new Microsoft.Toolkit.Uwp.UI.AdvancedCollectionView(FileList);
    
    //here we add sorting definitions, 
    //"DisplayName" is the current property we choose to sort against
    
    ObservableFileList.SortDescriptions.Add(new SortDescription("DisplayName",SortDirection.Descending)); 
     
    }
    
    
    void AcquireNewDataSet(){    
    //GetFiles should return your files with no particular order.    
    List<StorageFile>tmp = GetFiles();    
    //always prefer ReplaceRange
    FileList.ReplaceRange(tmp);    
    }
