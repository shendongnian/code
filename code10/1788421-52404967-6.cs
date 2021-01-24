    private static Vector2[] ConvertVector2(Vector2[] values)
    {
        var xs = values.Select(v => v.X); // .ToArray() for efficiency
        var ys = values.Select(v => v.Y); // .ToArray() for efficiency
        var min = new Vector2(xs.Min(), ys.Min());
        var max = new Vector2(xs.Max(), ys.Max());
        // If your Vector2 implements IComparable, use instead:
        // var min = values.Min();
        // var max = values.Max();
        return new[]
        {
            new Vector2(min.X, min.Y),
            new Vector2(max.X, max.Y),
            new Vector2(max.X, min.Y),
            new Vector2(min.X, max.Y),
        };
    }
