    // from is string representing type name, e.g. "System.Windows.Forms.Label"
    // to is string representing type name, e.g. "System.Windows.Forms.Control"
    Type fromType = Type.GetType(from);
    Type toType = Type.GetType(to);
    bool castable = from.IsCastableTo(to);
