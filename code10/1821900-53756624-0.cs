    interface IHasFruit {
        // I assume "Fruit" properties are of type "Fruit"?
        // Change the type to whatever type you use
        Fruit Fruit { get; }
    }
    class Tree : Detail, IHasFruit {
        ...
    }
    class Bush : Detail, IHasFruit {
        ...
    }
