    class State
    {
        public int Id { get; set; }
        public List<City> Children { get; set; }
        public State(int id, IEnumerable<City> childrenCities)
        {
            this.Id = id;
            this.Children = childrenCities.ToList();
            foreach (City city in this.Children)
                city.ParentState = this;
        }
    }
