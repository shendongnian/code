    public void UpdateMask(Texture tex)
    {
        //Debug.LogFormat("UpdateMask {0}", tex);
        m_SRenderer.GetPropertyBlock(m_SpriteMbp);
        m_SpriteMbp.SetTexture("_Mask", tex);
        Vector4 result = new Vector4(sprite.textureRect.position.x, sprite.textureRect.position.y, sprite.textureRect.size.x, sprite.textureRect.size.y)
         
        m_SpriteMbp.SetVector("_AtlasPosition", result)
        m_SRenderer.SetPropertyBlock(m_SpriteMbp);
    }
