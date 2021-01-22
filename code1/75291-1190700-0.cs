    public static ClassA<T> Clone<T>(this ClassA<T> self) {
        if (self == null) return null;
        return new ClassA { 
            Name = self.Name,
            ObjectT = self.ObjectT
        }
    }
