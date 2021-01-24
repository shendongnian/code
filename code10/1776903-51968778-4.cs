            static IEnumerable<RulePartModel> FindParts(RulePartModel obj)
        {
            var stack = new Stack<RulePartModel>();
            stack.Push(obj);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var item in current.Parts)
                    stack.Push(item);
            }
        }
