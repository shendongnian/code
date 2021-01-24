    public class NodeCreator : EditorWindow
    {
        ....
        [MenuItem ("Window/Node Creator")]
        static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(NodeCreator));
        }
        ....
        void OnGUI()
        {
            ....
                if (GUILayout.Button("Create"))
                {
                    tempobj = Instantiate(obj) as GameObject;
                    ...
                }
            ....
        }
