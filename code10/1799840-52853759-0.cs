    public bool Equals(Employee other)
    {
        if (other == null)
        {
            return false;
        }
        else
        {
            // Do your equality test here.
            return (this.ID = other.ID &&
                    this.Name = other.Name);
            // etc...
        }
    }
