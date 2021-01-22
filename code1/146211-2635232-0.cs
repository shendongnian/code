    public class People : IEnumerable<Person> {
        /* snip */
        public IEnumerator<Person> GetEnumerator() {
            return ((IEnumerable<Person>)_people).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() { return _people.GetEnumerator();}
    }
