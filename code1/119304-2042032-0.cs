    public IEnumerable<Dog> GrowAll(this IEnumerable<Puppy> puppies)
    {
        if(subjects == null)
            throw new ArgumentNullException("subjects");
        return GrowAllImpl(puppies);
    }
    
    private IEnumerable<Dog> GrowAllImpl(this IEnumerable<Puppy> puppies)
    {
        foreach(var puppy in puppies)
            yield return puppy.Grow();
    }
