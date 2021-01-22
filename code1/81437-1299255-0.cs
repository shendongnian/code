    public string Name
    {
        private string name; // Only accessible within the property
        get { return name; /* Extra processing here */ }
        set { name = value; /* Extra processing here */ }
    }
