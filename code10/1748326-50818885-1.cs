    IEnumerator ShowAd()
    {
        yield return new waitForSeconds(1);
        if (Advertisement.IsReady())
        {
            Advertisement.Show ();
        }
        else { StartCoroutine(ShowAd()); }
    }
