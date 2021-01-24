    private bool _isPlaying = false;
    public bool Isplaying
    {
        get { return _isPlaying; }
        set 
        {
            _isPlaying = value;
            if (_isPlaying)
            {
                // play vid here
            }
            else
            {
               // stop video here
            }
        }
    }
