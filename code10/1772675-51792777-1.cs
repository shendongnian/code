    bool IEqualityComparer.Equals(object x, object y) {
      if (x is T && y is T)
        return this.Equals((T)x, (T)y); // known types, run Equals
      else
        return object.Equals(x, y);     // unknown type(s), run default Equals 
    }
    int IEqualityComparer.GetHashCode(object obj) {
      if (obj is T)
        return this.GetHashCode((T)obj);
      else
        return null == obj ? 0 : obj.GetHashCode();
    }
