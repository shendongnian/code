    public void OnGUI()
    {
        //constantly grabbing the scene objects very slow store these into a collection then check the collection for changes..
        var gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        //sorting the array every time is also very slow
        Array.Sort(gameObjects, new SceneGameObjectComparer());
        hierarchyView.BeginHierarchyView();
        //this should be in some sort of class
        /*
         * public class GoInfo
         * {
         *    public string GoName;
         *    public int SiblingIndex;
         *    public GameObject object;
         * }
         * 
         * Store this into a collection and iterate it.
         */
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.transform.GetSiblingIndex();
            DrawGameObject(gameObject);
        }
        hierarchyView.EndHierarchyView();
        Repaint();
    }
      void OnHierarchyChange (){ //called on hierarchy changes }
