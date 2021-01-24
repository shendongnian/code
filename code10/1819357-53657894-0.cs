    int scenes = SceneManager.sceneCount;
    if (scenes > 1)
    {
        for (int i = 0; i < scenes; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Name of Maze Scene")
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i).name);
            }
        }
    }
