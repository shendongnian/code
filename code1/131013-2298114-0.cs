    private List<object> objs;
    public ReadOnlyCollection<object> Objs {
        get {
            return objs.AsReadOnly();
        }
    }
