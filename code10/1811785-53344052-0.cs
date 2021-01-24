    public Image Corner;
    IEnumerator AnimationGif(Sprite[] gifArray, float timeBetweenFrames)
    {
        for (int x = 0; x < gifArray.Length; x++)
        {
            Corner.sprite = gifArray[x];
            yield return new WaitForSecondsRealtime(timeBetweenFrames);
        }
    }
