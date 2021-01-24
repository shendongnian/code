    class Policy
    {
        string Name { get; set; }
        DateTime InceptionDate { get; set; }
        DateTime ExpirationDate { get; set; }
        [VectorType(4)]
        float[] Locations { get; set; }
    }
