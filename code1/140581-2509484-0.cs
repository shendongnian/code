    var z = l.Aggregate(new Stack<KeyValuePair<DateTime, TimeSpan>>(),
                        (s, dt) =>
                          {
                            var ts = s.Count > 0 ? dt - s.Peek().Key : TimeSpan.Zero;
                            s.Push(new KeyValuePair<DateTime, TimeSpan>(dt, ts));
                            return s;
                          })
              .Where(kv=>!kv.Value.Equals(TimeSpan.Zero))
              .Select(kv => kv.Value)
              .ToList();
