            static void Main(string[] args)
        {
            var testobj = new RulePartModel();
            var results = FindParts(testobj, q => q.Value == "123");
            // results =>>> all objects with your condition
        }
        static IEnumerable<RulePartModel> FindParts(RulePartModel obj, Func<RulePartModel, bool> predicate)
        {
            if (predicate.Invoke(obj))
                yield return obj;
            foreach (var item in obj.Parts)
                foreach (var res in FindParts(item, predicate))
                    yield return res;
        }
