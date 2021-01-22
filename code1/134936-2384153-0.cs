    public bool Equals(Editeur other)
    {
        return (this.Nom == other.Nom);            
    }
    public override bool Equals(object obj)
    {
        if (obj is Editeur)
        {
            return Equals(obj as Editeur);
        }
        return false;
    }
