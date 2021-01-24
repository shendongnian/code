    Dictionary<GameObject, Renderer> renderers = new Dictionary<GameObject, Renderer>();
    private void Awake()
    {
        foreach(var textMesh in Textmeshes)
        {
            renderers[textMesh]= textMesh.GetComponent<Renderer>();
            // And hide all from beginning
            renderers[textMesh].enabled = false;
        }
        // Then enable the first one
        Num = 0;
        ToggleRenderer(0);
    }
