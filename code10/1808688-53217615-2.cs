    EditorGUIHierarchyView hierarchyView = new EditorGUIHierarchyView();
    private static GameObject[] _sceneObjects;
    [MenuItem("Window/EditorGUIHierarchy - Show Scene View")]
    static void Init()
    {
        EditorGUIHierarchyViewExampleWindow window = (EditorGUIHierarchyViewExampleWindow)GetWindow(typeof(EditorGUIHierarchyViewExampleWindow));
        _sceneObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        Array.Sort(_sceneObjects, new SceneGameObjectComparer());
        window.Show();
    }
    struct SceneGameObjectComparer : IComparer<GameObject>
    {
        public int Compare(GameObject go1, GameObject go2)
        {
            return go1.transform.GetSiblingIndex().CompareTo(go2.transform.GetSiblingIndex());
        }
    }
    void OnEnable()
    {
        this.titleContent = new GUIContent("Scene View");
    }
    public void OnGUI()
    {
       hierarchyView.BeginHierarchyView();
        foreach (GameObject gameObject in _sceneObjects)
        {
            gameObject.transform.GetSiblingIndex();
            DrawGameObject(gameObject);
        }
        hierarchyView.EndHierarchyView();
        Repaint();
    }
    void DrawGameObject(GameObject go)
    {
        if (go.transform.childCount > 0)
        {
            if (go.activeInHierarchy)
            {
                hierarchyView.BeginNode(go.name);
            }
            else
            {
                hierarchyView.BeginNode(go.name, Color.gray, Color.gray);
            }
            foreach (Transform child in go.transform)
            {
                DrawGameObject(child.gameObject);
            }
            hierarchyView.EndNode();
        }
        else
        {
            if (go.activeInHierarchy)
            {
                hierarchyView.Node(go.name);
            }
            else
            {
                hierarchyView.Node(go.name, Color.gray, Color.gray);
            }
        }
    }
