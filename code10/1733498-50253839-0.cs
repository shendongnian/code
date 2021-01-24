    private List<GameObject> rootGameObjects = new List<GameObject>();
    private List<Transform> childObjs = new List<Transform>();
    
    private void GetAllRootObject()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        activeScene.GetRootGameObjects(rootGameObjects);
    }
    
    private void GetAllChildObjs()
    {
        for (int i = 0; i < rootGameObjects.Count; ++i)
        {
            GameObject obj = rootGameObjects[i];
    
            //Get all child components attached to this GameObject
            obj.GetComponentsInChildren<Transform>(true, childObjs);
        }
    }
