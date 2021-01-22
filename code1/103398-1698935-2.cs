    protected const float EqualityVariance = 0.0000001;
    public override bool Equals(object obj)
    {
        Vector3? vector = obj as Vector3?;
        if (vector == null) return false;
        return Equals((Vector3)vector);
    }
    public bool Equals(Vector3 vector)
    {
        return Math.Abs(this._x - vector._x) < EqualityVariance && 
               Math.Abs(this._y - vector._y) < EqualityVariance && 
               Math.Abs(this._z - vector._z) < EqualityVariance;
    }
