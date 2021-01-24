    private static Vector2[] ConvertVector2(Vector2[] values)
    {
        var initial = new Stats2(float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
        return values.Aggregate(initial,Stats2.Apply,
            acc => new [] {
                new Vector2(acc.MinX, acc.MinY),
                new Vector2(acc.MaxX, acc.MaxY),
                new Vector2(acc.MaxX, acc.MinY),
                new Vector2(acc.MinX, acc.MaxY),
            });
    }
