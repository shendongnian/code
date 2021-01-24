    //Raw Image to Show Video Images [Assign from the Editor]
    public RawImage image;
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    //Audio
    private AudioSource audioSource;
    //Server url
    string url = "http://127.0.0.1:8080/";
    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }
    IEnumerator playVideo()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        //We want to play from url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
        //Prepare Audio to prevent Buffering
        videoPlayer.Prepare();
        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }
        Debug.Log("Done Preparing Video");
        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;
        //Play Video
        videoPlayer.Play();
        //Play Sound
        audioSource.Play();
        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        Debug.Log("Done Playing Video");
    }
