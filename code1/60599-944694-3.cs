    // below code makes the getter thread safe
    private object builderConstructionSynch = new object();
    public StringBuilder Builder
    {
        get
        {
            lock (builderConstructionSynch)
            {
                if (_builder == null) _builder = new StringBuilder();
            }
            return _builder;
        }
    }
