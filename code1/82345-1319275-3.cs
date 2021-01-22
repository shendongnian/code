    public static IEnumerable<Person> ClassifyAs(
        this IEnumerable<Person> input, string classification)
    {
        foreach (var p in input)
        {
            p. PersonClassification = classification;
            yield return p;
        }
    }
