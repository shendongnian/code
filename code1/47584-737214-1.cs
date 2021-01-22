    private List<string> GetPicture4(string Folder)  //you need to define the type of list you are returning
    {
    	DirectoryInfo dir = new DirectoryInfo(Folder);
        List<string> str = new List<string>();
        FileInfo[] files = dir.GetFiles("*.jpg", SearchOption.AllDirectories);   
        int NumOfFiles = files.Length; //here you are missing a type, int in this case
        imgExtension = new string[NumOfFiles];
    
        for (int i = 0; i < NumOfFiles; i++)
        {
            ARR(i, files[i].FullName); //pass i instead of NumOfFiles else in ARR the creating of the picturebox gets the same ID everytime
            str.Add(files[i].FullName);
        }
    
    	return str;
    }
