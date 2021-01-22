    class Category
    {
        ArrayList Next;
        string name;
        public Category()
        {
            name = "";
            Next = new ArrayList();
        }
        public Category(string name)
        {
            this.name = name;
            Next = new ArrayList();
        }
        public void Add(string name)
        {
            Next.Add(new Category(name));
        }
        public Category Find(string name)
        {
            Category a;
            foreach (Category c in Next)
            {
                if (c.name == name)
                    return c;
                a = c.Find(name);
                if (a != null) return a;
            }
            return null;
        }
      //  other functions you need
    }
