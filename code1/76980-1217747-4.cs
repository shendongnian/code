    // inner class
    private class Magic
    {
        private T t;
        private IList<T> list;
        private Magic(List<T> list, T t) { this.list = list; this.t = t;}
    
        public IEnumerable<T> DoIt()
        {
            var items = () => {
                foreach (var item in list)
                    if (fun.Invoke(item))
                        yield return item;
            }
        }
    }
    public IList<T> GreaterThan<T>(T t)
    {
        var magic = new Magic(GetList<T>(), t)
        var items = magic.DoIt();
        return items.ToList();
    }
