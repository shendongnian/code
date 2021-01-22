    private List<Foo> internalList;
    private ReadOnlyCollection<Foo> externalList;
    public ReadOnlyCollection<Foo> RepositoryCollection {
        get {
            if (externalList == null) {
                externalList = internalList.AsReadOnly();
            }
            return externalList;
        }
    }
