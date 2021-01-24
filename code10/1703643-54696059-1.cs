    operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                new Dictionary<string, IEnumerable<string>>
                {
                    {"jwt", _scopes }
                }
