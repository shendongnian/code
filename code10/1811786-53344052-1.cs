    public Image Corner;
    
    IEnumerator AnimationGif(Sprite[] gifArray, float timeBetweenFrames)
    {
        foreach (Sprite x in gifArray)
        {
            Corner.sprite = x;
            yield return new WaitForSecondsRealtime(timeBetweenFrames);
        }
    }
