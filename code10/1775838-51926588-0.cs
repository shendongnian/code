    public AudioSource MyAudioSource;
    public Button PlayBtn;
    public PlayButtonText;
    void Start()
    {
        PlayBtn.onClick.AddListener(() =>
        {
            if (MyAudioSource.isPlaying)
            {
                MyAudioSource.Stop();
                PlayButtonText.text = "Play me!";
            }
            else
            {
                MyAudioSource.Play();
                PlayButtonText.text = "Stop me!";
            }
        });
    }
