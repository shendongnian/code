    IEnumerator LoadSceneAsyncIEnumerator(string sceneName, SomeScriptableObject scriptable)
    {
        yield return null;
        var targetCount = scriptable.jeux.Count();
        var loadedCount = 0;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        foreach (var j in scriptable.jeux)
        {
            // for each image that is processed, increment the counter
            StartCoroutine(LoadImageAsync(j.image1,() =>
            {
                loadedCount++;
            }));
        }
        while (!asyncLoad.isDone || targetCount != loadedCount)
        {
            yield return null;
        }
    }
 
