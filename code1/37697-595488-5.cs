    public Person FindById(int id)
    {
        return this.Find(delegate(Person p)
        {
            return (p.Id == id);
        });
    }
