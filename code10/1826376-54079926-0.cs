    var go = GameObject.Instantiate(modelAsset);
    GameObjectUtility.SetStaticEditorFlags(modelAsset, (StaticEditorFlags)(-1));
    foreach (Transform child in go.transform)
    {
        if (child.name.Contains("UCX_"))
        {
            Renderer rend;
            rend = child.GetComponent<Renderer>();
            rend.enabled = !rend.enabled;
            child.gameObject.AddComponent<MeshCollider>();
        }
    }
    PrefabUtility.SaveAsPrefabAsset(go, destinationPath);
    GameObject.DestroyImmediate(go);
