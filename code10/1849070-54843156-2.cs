    public class World : Root<Continent>
    {
        protected override void SetChildsParent(Continent child) => child.Parent = this;
    }
    public class Continent : Node<World, Country>
    {
        protected override void SetChildsParent(Country child) => child.Parent = this;
    }
    public class Country : Node<Continent, State>
    {
        protected override void SetChildsParent(State child) => child.Parent = this;
    }
    public class State : Node<Country, City>
    {
        protected override void SetChildsParent(City child) => child.Parent = this;
    }
    public class City : Leaf<State> { }
