    using FastMember;
    using Dynamic;
    using System;
    using System.Linq;
    using System.Collections.Generic
    
    public static class Utilities
    {
        public static dynamic GetDynamicFields<TEntity>(this TEntity entity, params string[] fields)
            where TEntity : class
        {
            dynamic dynamic = new ExpandoObject();
            // ExpandoObject supports IDictionary so we can extend it like this
            IDictionary<string,object> dictionary = dynamic as IDictionary<string,object>;
            TypeAccessor typeAccessor = TypeAccessor.Create(typeof(TEntity));
            ObjectAccessor accessor = ObjectAccessor.Create(entity);
            IDictionary<string,Member> members = typeAccessor.GetMembers().ToDictionary(x => x.Name);
            for (int i = 0; i < fields.Length; i++)
            {
                if (members.ContainsKey(fields[i]))
                {
                    var prop = members[fields[i]];
                    if (dictionary.ContainsKey(prop.Name))
                        dictionary[prop.Name] = accessor[prop.Name];
                    else
                        dictionary.Add(prop.Name, accessor[prop.Name]);
                }
            }
            return dynamic;
        }
    }
