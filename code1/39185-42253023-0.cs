     public static void DynamicPropertySet(object source, object target)
        {
            //SOURCE
            var src_accessor = TypeAccessor.Create(source.GetType());
            if (src_accessor == null)
            {
                throw new ApplicationException("Could not create accessor!");
            }
            var src_members = src_accessor.GetMembers();
            if (src_members == null)
            {
                throw new ApplicationException("Could not fetch members!");
            }
            var src_class_members = src_members.Where(x => x.Type.IsClass && !x.Type.IsPrimitive);
            var src_class_propNames = src_class_members.Select(x => x.Name);
            var src_propNames = src_members.Except(src_class_members).Select(x => x.Name);
            //TARGET
            var trg_accessor = TypeAccessor.Create(target.GetType());
            if (trg_accessor == null)
            {
                throw new ApplicationException("Could not create accessor!");
            }
            var trg_members = trg_accessor.GetMembers();
            if (trg_members == null)
            {
                throw new ApplicationException("Could not create accessor!");
            }
            var trg_class_members = trg_members.Where(x => x.Type.IsClass && !x.Type.IsPrimitive);
            var trg_class_propNames = trg_class_members.Select(x => x.Name);
            var trg_propNames = trg_members.Except(trg_class_members).Select(x => x.Name);
            var class_propNames = trg_class_propNames.Intersect(src_class_propNames);
            var propNames = trg_propNames.Intersect(src_propNames);
            foreach (var propName in propNames)
            {
                trg_accessor[target, propName] = src_accessor[source, propName];
            }
            foreach (var member in class_propNames)
            {
                var src = src_accessor[source, member];
                var trg = trg_accessor[target, member];
                if (src != null && trg != null)
                {
                    DynamicPropertySet(src, trg);
                }
            }
        }
