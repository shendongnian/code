    public class Repo<T> where T : class
    {
        private IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }
        private bool FilterOnId(dynamic input, int id)
        {
            return input.Id == id;
        }
        public T GetById(int id)
        {
            return this.All().Single(t => FilterOnId(t, id));
        }
    }
