    public bool Equals(Complex other)
    {
        return (this.RealPart == other.RealPart)
            && (this.ImaginaryPart == other.ImaginaryPart);
    }
    public override bool Equals(object other)
    {
        if (other == null) return base.Equals(other);
        if (other is Complex)
        {
            return this.Equals((Complex)other);
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return this.RealPart.GetHashCode() ^ this.ImaginaryPart.GetHashCode();
    }
