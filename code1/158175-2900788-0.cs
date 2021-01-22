        public class PersonComparer : IComparer
        {
            public int Compare(object a, object b)
            {
                Person pa = a as Person;
                Person pb = b as Person;
                if (pa == pb) return 0;
                if (pa == null) return -1;
                if (pb == null) return 1;
                return string.Compare(pa.Name, pb.Name);
            }
        }
        ...
        arrayList.Sort(new PersonComparer());
