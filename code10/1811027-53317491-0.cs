       public AudioSource backgroundmusic;
    public string sound;
    public GameObject SoundOnButton, SoundOffButton, Canvas;
    public bool muted, notloaded = false;
    void Start()
    {
        SoundCheck();
        if (notloaded == false)
        {
            if (Canvas == true)
            {
                SoundON();
                notloaded = true;
            }
        }
    }
    public void SoundOFF()
    {
        muted = false;
        PlayerPrefs.SetString("Sound", "enabled");
        SoundCheck();
    }
    public void SoundON()
    {
        muted = true;
        PlayerPrefs.SetString("Sound", "muted");
        SoundCheck();
    }
    public void SoundCheck()
    {
        sound = PlayerPrefs.GetString("Sound");
        if (sound == "enabled")
        {
            muted = false;
            SoundOffButton.SetActive(false);
            SoundOnButton.SetActive(true);
            backgroundmusic.Pause();
            Debug.Log("Enabled");
        }
        if (sound == "muted")
        {
            muted = true;
            SoundOffButton.SetActive(true);
            SoundOnButton.SetActive(false);
            backgroundmusic.Play();
            Debug.Log("Muted");
        }
    }
}
