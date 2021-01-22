    private List<Foo> internalList;
    public List<Foo> RepositoryCollection {
        get {
            return new List<Foo>(interalList);
        }
    }
