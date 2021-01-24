    GameObject[] objects = Selection.gameObjects;
    if (EditorUtility.DisplayDialog("Title", "Msg", "Ok"))
    {
        Debug.Log(objects[0]);
    
        // ... //
    }
