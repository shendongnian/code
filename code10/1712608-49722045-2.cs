    class IgnoreNullSourceValues : IMemberValueResolver<object, object, object, 
    object>
    {
        public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
        {
            if (destinationMember is IList)
            {
                var a = (IList)sourceMember;
                if (a == null || a.Count == 0)
                    return CopyIList(destinationMember as IList);
            }
            if (sourceMember is DateTime)
            {
                var a = (DateTime)sourceMember;
                if (a == DateTime.MinValue)
                    return destinationMember;
            }
            return sourceMember ?? destinationMember;
        }
        private static IList CopyIList(IList list)
        {
            var ret = (IList)Activator.CreateInstance(list.GetType());
            foreach (var item in list)
                ret.Add(item);
            return ret;
        }
    }
