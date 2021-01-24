        static IEnumerable<Tuple<System, System>> ZipLongest(IEnumerable<System> T1, IEnumerable<System> T2)
        {
            //We want to enumerate to the longest collection
            int length = Math.Max(T1.Count(), T2.Count());
            var e1 = T1.GetEnumerator();
            var e2 = T2.GetEnumerator();
            //We will use this to output null if a collection does not contain new elements
            var e1Done = false;
            var e2Done = false;
            for (int i = 0; i < length; i++)
            {
                e1Done = !e1.MoveNext();
                e2Done = !e2.MoveNext();
                var system1 = e1Done ? null : e1.Current;
                var system2 = e2Done ? null : e2.Current;
                yield return new Tuple<System, System>(system1, system2);
            }
        }
