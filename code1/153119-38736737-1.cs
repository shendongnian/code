    #region ICloneable
    public object Clone()
    {
        return this.DeepCopyByExpressionTree();
    }
    #endregion
