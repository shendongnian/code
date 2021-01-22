    // Using Color as enum just to make things clearer
    class ClassyClass
    {
        public string Name {get; private set;}
        public Color Color {get; private set;}
        public ClassyClass(id, string name, Color color) { ... }
    }
    
    var orderedList = collectionOfClassyClasses
                .OrderBy(x => x.Color != Color.Red) // False comes before true
                .ThenBy(x => x.Color)
                .ThenBy(x => x.Name)
                .ToList();
