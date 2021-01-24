    public void PlayNow()
    {
        Debug.Log("scene should be changed");
        StartCoroutine(PlayNowCoroutine);
    }
    IEnumerator PlayNowCoroutine()
    {
        float fadeTime = GameObject.Find("SceneEngine").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single); 
    }
