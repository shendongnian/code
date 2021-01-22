    public bool Equals(Complex other)
    {
        // Complex is a value type, thus we don't have to check for null
        // if (other == null) return false;
        return (this.RealPart == other.RealPart)
            && (this.ImaginaryPart == other.ImaginaryPart);
    }
    public override bool Equals(object other)
    {
        // other could be a reference type, the is operator will return false if null
        if (other is Complex)
            return this.Equals((Comple)other);
        else
            return false;
    }
    public override int GetHashCode()
    {
        return this.RealPart.GetHashCode() ^ this.ImaginaryPart.GetHashCode();
    }
