            var leaf = kvp.Value as IDictionary<string, string>;
            if (leaf != null)
            {
                HandleDict(leaf);
            }
            else
            {
                HandleDict((IDictionary<string, object>)kvp.Value);
            }
        }
    }
