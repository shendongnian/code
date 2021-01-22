    public class PersonsWriter : IDisposable
    {
        private StreamWriter _wr;
        public PersonsWriter(IList<Person> persons, StreamWriter writer)
        {
            this._wr = writer;
        }
        public void Write(IList<Persons> people) {
            foreach(Person dude in people)
            {
                _wr.Write(@"{0} {1}\n{2}\n{3} {4}\n\n",
                    dude.FirstName,
                    dude.LastName,
                    dude.StreetAddress,
                    dude.ZipCode,
                    dude.City);
            }
        }
        public void Dispose()
        {
            _wr.Flush();
            _wr.Dispose();
        }
    }
