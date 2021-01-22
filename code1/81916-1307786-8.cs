    public bool Equals(double otherReal)
    {
        return (this.RealPart == otherReal) && (this.ImaginaryPart == 0.0);
    }
    public override bool Equals(object other)
    {
        if (other == null) return base.Equals(other);
        if (other is Complex)
        {
            return this.Equals((Complex)other);
        }
        else if (other is double)
        {
            return this.Equals((double)other);
        }
        else
        {
            return false;
        }
    }
