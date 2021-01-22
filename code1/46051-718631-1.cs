    public interface ILocationRepository
    {
        IList<Location> FindAll(int start, int size);
        IList<Location> FindForState(State state, int start, int size);
        IList<Location> FindForPostCode(string postCode, int start, int size);
    }
