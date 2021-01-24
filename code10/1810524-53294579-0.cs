        private void Start()
    {
        lastLevelViewed = PlayerPrefsManager.GetLastLevelViewed();
        if(lastLevelViewed > 0)
        {
            scrollRect.horizontalScrollbar.value = PlayerPrefsManager.GetLastLevelViewed();
        }
        else
        {
            scrollRect.horizontalScrollbar.value = 0;
        }
    }
    // Sets the camera coordinates.
    public void SetCameraCoordinates()
    {
        PlayerPrefsManager.SetLastLevelViewed(scrollRect.horizontalScrollbar.value);
    }
