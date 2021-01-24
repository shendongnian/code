    private MeshRenderer meshRenderer;
    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color newColor)
    {
        renderer.material.color = newColor;
    }
