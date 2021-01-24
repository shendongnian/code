    private List<object> ObjectsToLoad = new List<object>();
    private void DoCoolStuff() {
        int objectsLoaded = 0;
        foreach (object o in ObjectsToLoad) {
            // Process the object.
            Progress = (float)++objectsLoaded / (float)ObjectsToLoad.Count;;
            OnObjectLoaded();
        }
    }
