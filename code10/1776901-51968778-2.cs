            static IEnumerable<RulePartModel> FindParts(RulePartModel obj)
        {
            var stack = new Stack<RulePartModel>();
            stack.Push(obj);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var item in obj.Parts)
                    stack.Push(item);
            }
        }
