        public class Things : List<Thing>, IThings
        {
            IEnumerator<IThing> IEnumerable<IThing>.GetEnumerator()
            {
                foreach (Thing t in this)
                {
                    yield return t;
                }
            }
        }
