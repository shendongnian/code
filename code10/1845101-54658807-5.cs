    // true turns it into a validation method
    [MenuItem("GameObject/Test", true, -10)]
    private static bool IsCanera()
    {
        return Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Camera>();
    }
