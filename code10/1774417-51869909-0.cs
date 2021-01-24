    public void ColorSet(Color color)
    {
      renderer.GetPropertyBlock(matBlock);
      matBlock.SetColor("_Color", color);
      renderer.SetPropertyBlock(matBlock);       
    }
