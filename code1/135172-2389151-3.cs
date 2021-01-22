    public override bool Equals(object obj)
    {
       IFieldLookup other = obj as IFieldLookup;
       if (other == null)
            return false;
       return other.FileName.Equals(this.FileName, StringComparison.InvariantCultureIgnoreCase) && other.FieldName.Equals(this.FieldName, StringComparison.InvariantCultureIgnoreCase);
    }
    public override int GetHashCode()
    {
        return StringComparer.InvariantCulture.GetHashCode(FileName) +
               StringComparer.InvariantCulture.GetHashCode(FieldName);
    }
