    public override bool Equals(object obj) { 
        Href other = obj as Href;
        return other != null && URL.Equals(other.URL);
    } 
    public override int GetHashCode() { 
        return URL.GetHashCode();
    } 
