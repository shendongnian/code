    [Flags] enum E { None = 0, A = '1', B = '2', C = '4' }
    public static bool IsDefined<T>(T value) where T : Enum
    {
	    var values = Enum.GetValues(typeof(T)).OfType<dynamic>().Aggregate((e1, e2) => (e1 | e2));
        return (values & value) == value;
    }
    // IsDefined(ExportFormat.Csv); // => True
	// IsDefined(ExportFormat.All); // => True
	// IsDefined(ExportFormat.All | ExportFormat.None); // => True
	// IsDefined(ExportFormat.All | ExportFormat.Csv); // => True
	// IsDefined((ExportFormat)16); // => False
    // IsDefined((ExportFormat)int.MaxValue); // => False
	// IsDefined(E.A); // => True
	// IsDefined(E.A | E.B); // => True
	// IsDefined((E)('1' | '2')); // => True
	// IsDefined((E)('5')); // => True
	// IsDefined((E)5); // => True
	// IsDefined((E)8); // => False
	// IsDefined((E)int.MaxValue); // => False
