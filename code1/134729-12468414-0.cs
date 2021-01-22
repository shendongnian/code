           foreach (var side in Lines) {
                if (point.Y > Math.Min(side.Start.Y, side.End.Y))
                    if (point.Y <= Math.Max(side.Start.Y, side.End.Y))
                        if (point.X <= Math.Max(side.Start.X, side.End.X)) {
                            if (side.Start.Y != side.End.Y) {
                                float xIntersection = (point.Y - side.Start.Y) * (side.End.X - side.Start.X) / (side.End.Y - side.Start.Y) + side.Start.X;
                                if (side.Start.X == side.End.X || point.X <= xIntersection)
                                    result = !result;
                            }
                        }
            }
