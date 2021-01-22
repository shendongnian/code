    public abstract class Parser
    {
        public abstract IEnumerable<Movie> Parse(string criteria);
    }
    
    public class ByTitleParser: Parser
    {
        public override IEnumerable<Movie> Parse(string title)
        {
            // TODO: Logic to parse movie information by title
            // Likely to return one movie most of the time, but some movies from different eras may have the same title
        }
    }
    
    public class ByActorParser: Parser
    {
        public override IEnumerable<Movie> Parse(string actor)
        {
            // TODO: Logic to parse movie information by actor
            // This one can return more than one movie, as an actor may act in more than one movie
        }
    }
    
    public class ByIdParser: Parser
    {
        public override IEnumerable<Movie> Parse(string id)
        {
            // TODO: Logic to parse movie information by id
            // This one should only ever return a set of one movie, since it is by a unique key
        }
    }
