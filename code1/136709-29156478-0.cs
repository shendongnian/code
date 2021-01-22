        public Tuple<bool, object> Evaluate(IScopeContext c, object obj, string methodName, object[] args)
        {
            // Get the type of the object
            var t = obj.GetType();
            var argListTypes = args.Select(a => a.GetType()).ToArray();
            var funcs = (from m in t.GetMethods()
                         where m.Name == methodName
                         where m.ArgumentListMatches(argListTypes)
                         select m).ToArray();
            if (funcs.Length != 1)
                return new Tuple<bool, object>(false, null);
            // And invoke the method and see what we can get back.
            // Optional arguments means we have to fill things in.
            var method = funcs[0];
            object[] allArgs = args;
            if (method.GetParameters().Length != args.Length)
            {
                var defaultArgs = method.GetParameters().Skip(args.Length)
                    .Select(a => a.HasDefaultValue ? a.DefaultValue : null);
                allArgs = args.Concat(defaultArgs).ToArray();
            }
            var r = funcs[0].Invoke(obj, allArgs);
            return new Tuple<bool, object>(true, r);
        }
