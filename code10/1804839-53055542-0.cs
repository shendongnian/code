    public static bool HasAllComponents(GameObject gameObject, params System.Type[] types)
    {
        for (int i = 0; i < types.Length; i++)
        {
            if (gameObject.GetComponent(types[i]) == null)
                return false;
        }
        return true;
    }
