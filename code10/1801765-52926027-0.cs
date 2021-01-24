    public AddChildren(Table t) {
        var parent = this;
        while ( parent != null ) {
            if ( parent.Id == t.Id )
                throw new Exception("cycle");
            parent = parent.Parent;
        }
        Children.Add(t);
    }
