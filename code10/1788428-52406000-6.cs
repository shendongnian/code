        private static Vector3[] ConvertVector3(Vector3[] values)
        {
            var zValue = values[0].Z;
            var initial = new Stats2(float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);
            return values.Aggregate(initial,
                (acc, point) => new Stats2(
                        Math.Max(point.X, acc.MaxX),
                        Math.Min(point.X, acc.MinX),
                        Math.Max(point.Y, acc.MaxY),
                        Math.Min(point.Y, acc.MinY)),
                acc => new [] {
                      new Vector3(acc.MinX, acc.MinY,zValue),
                      new Vector3(acc.MaxX, acc.MaxY,zValue),
                      new Vector3(acc.MaxX, acc.MinY,zValue),
                      new Vector3(acc.MinX, acc.MaxY,zValue),
                });
        }
