    public static void CreateSortingLayer(string layerName)
    {
        var serializedObject = new SerializedObject(AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset"));
        var sortingLayers = serializedObject.FindProperty("m_SortingLayers");
        for (int i = 0; i < sortingLayers.arraySize; i++)
            if (sortingLayers.GetArrayElementAtIndex(i).FindPropertyRelative("name").stringValue.Equals(layerName))
                return;
        sortingLayers.InsertArrayElementAtIndex(sortingLayers.arraySize);
        var newLayer = sortingLayers.GetArrayElementAtIndex(sortingLayers.arraySize - 1);
        newLayer.FindPropertyRelative("name").stringValue = layerName;
        serializedObject.ApplyModifiedProperties();
    }
