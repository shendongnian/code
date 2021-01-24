    public AudioSource aSource;
    
    public string path = @"/mnt/sdcard/music";
    private FileInfo[] info;
    private DirectoryInfo dir;
    
    IEnumerator LoadAndPlaySound()
    {
        //Get the proper path with DirectoryInfo
        dir = new DirectoryInfo(path);
        //Get all .mp3 files in the folder
        info = dir.GetFiles("*.mp3");
    
        //Use the first audio index found in the directory
        string audioPath = "file:///" + info[0].FullName;
    
        using (WWW www = new WWW(audioPath))
        {
            yield return www;
    
            //Set the AudioClip to the loaded one
            aSource.clip = www.GetAudioClip(false, false);
            //Play Audio
            aSource.Play();
        }
    }
