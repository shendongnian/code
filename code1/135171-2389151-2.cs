    public override bool Equals(object obj)
    {
       IFieldLookup other = obj as IFieldLookup;
       if (other == null)
            return false;
       return other.FileName.Equals(this.FileName) && other.FieldName.Equals(this.FieldName);
    }
    public override int GetHashCode()
    {
        return FileName.GetHashCode() + FieldName.GetHashCode();
    }
