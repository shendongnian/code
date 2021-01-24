    // Dictionary to store the references to the Renderer components
    // Makes it easier to find them later
    // You could as well only use a List instead and rely on the index
    Dictionary<GameObject, Renderer> renderers = new Dictionary<GameObject, Renderer>();
    private void Awake()
    {
        // Get all references already at app start
        foreach(var textMesh in Textmeshes)
        {
            renderers[textMesh] = textMesh.GetComponent<Renderer>();
            // And hide all from beginning
            renderers[textMesh].enabled = false;
        }
        // Then enable only the first one depending what your Num is at start
        SanatizeNum();
        SetRendererEnabled(Num, true);
    }
