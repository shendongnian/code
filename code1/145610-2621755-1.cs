    List<RadioButton> listUserControlBtns = new List<RadioButton>(); 
    var btnLocalFolder = new CustomLocalFolderButton() {Content = "Label 1"}; 
    var btnPlayListFolder = new CustomLocalFolderButton() {Content = "Label 2"};  
    var btnVideoFolder = new CustomVideoButton() {Content = "Label 3"}; 
    var btnMusicFolder = new CutsomAudioButton() {Content = "Label 4"}; 
    var btnImageFolder = new CustomImageButton()  {Content = "Label 5"}; 
    
    listUserControlBtns.Add(btnLocalFolder);  
    listUserControlBtns.Add(btnPlayListFolder); 
    listUserControlBtns.Add(btnVideoFolder); 
    listUserControlBtns.Add(btnMusicFolder); 
    listUserControlBtns.Add(btnImageFolder); 
     
    listMainFolder.ItemsSource = listUserControlBtns; 
