    public interface IResourceSupplier
    {
        // Returns the localized text for a given identifier.
        string Localized(string identifier);
        // Returns the invariant (English) text for a given identifier.
        string Invariant(string identifier);
    }
