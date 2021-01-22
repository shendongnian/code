    bool Clean(ActionSet nodes)
        {
            if (nodes != null)
            {
                var removed = nodes.Where(n => this.IsNullOrNotPermitted(n) || !this.IsNotSetOrNotEmpty(n) || !this.Clean(n as ActionSet));
                removed.ToList().ForEach(n => nodes.Remove(n));
                return nodes.Any();
            }
            return true;
        }
        bool IsNullOrNotPermitted(IActionItem node)
        {
            return node == null || *YourTest*(node.Call);
        }
        bool IsNotSetOrNotEmpty(IActionItem node)
        {
            var hset = node as ActionSet;
            return hset == null || hset.Any();
        }
