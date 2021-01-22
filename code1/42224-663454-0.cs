    public object Execute(object target, IEnumerable<string> memberNames, IEnumerable<object[]> args)
        {
            if(memberNames.Count() == 0)
                return target;
            string currentMember = memberNames.First();
            object[] currentArgs = args.First();
            object value;
            if (currentArgs.Length == 0)
            {
                //property
                PropertyInfo pi = target.GetType().GetProperty(currentMember);
                value = pi.GetValue(target, null);
            }
            else
            {
                //method
                MethodInfo mi = target.GetType().GetMethod(currentMember);
                value = mi.Invoke(target, currentArgs);
            }
            return Execute(value, memberNames.Skip(1), args.Skip(1));
        }
