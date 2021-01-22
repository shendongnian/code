    class Example : ICloneable
    {
        private void CallClone()
        {
            object clone = ((ICloneable)this).Clone();
        }
        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }
    }
