    IEnumerable<string> ShortestPath(string fromState, string toState, Transition[] currentTransitions) {
        var map = new Dictionary<string, string>();
        var edges = currentTransitions.ToDictionary(i => i.From, i => i.To);
        var q = new Queue<string>(); 
        map.Add(fromState, null);
        q.Add(fromState);
        while (q.Count > 0) {
            var current = q.Dequeue();
            foreach (var s in edges[current]) {
                if (!map.ContainsKey(s)) {
                    map.Add(s, current);
                    if (s == toState) {
                        var result = new Stack<string>();
                        do {
                            result.Push(s);
                            s = map[s];
                        } while (s != fromState);
                        while (result.Count > 0)
                            yield return result.Pop();
                        yield break;
                    }
                    q.Enqueue(s);
                }
            }
        }
        // no path exists
    }
