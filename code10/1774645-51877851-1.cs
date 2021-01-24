    public class Abc
    {
        public Abc(int id)
        {
            Id = id;
        }
        public int Id { get; }
        public List<Abc> Child { get; set; }
        public Abc FindById(int id)
        {
            if (Id == id) return this;
            if (Child == null) return null;
            foreach (var childItem in Child)
            {
                var result = childItem.FindById(id);
                if (result != null) return result;
            }
            return null;
        }
        public bool HasChild(int id)
        {
          return FindById(id) != null;
        }
        public Abc AddChildIfNotExist(Abc child)
        {
            if (child == null) return this;
            if (!HasChild(child.Id))Child.Add(child);
            return this;
        }
    }
        static void Main(string[] args)
        {
            var a = new Abc(1)
            {
                Child = new List<Abc>
                {
                    new Abc(2),
                    new Abc(3)
                    {
                        Child = new List<Abc>
                        {
                            new Abc(7)
                            {
                                Child = new List<Abc>
                                {
                                    new Abc(5)
                                }
                            }
                        }
                    },
                    new Abc(6)
                    {
                        Child = new List<Abc>
                        {
                            new Abc(8)
                            {
                                Child = new List<Abc>
                                {
                                    new Abc(9),
                                    new Abc(4)
                                    {
                                       Child = new List<Abc>()
                                    }
                                }
                            }
                        }
                    }
                }
            };
            a
                .FindById(4)
                .AddChildIfNotExist(new Abc(10))
                .AddChildIfNotExist(new Abc(4));
        }
