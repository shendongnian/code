    public class Matches
    {
        public int Id  { get; set; }
    
        // these two properties below represent the foreign key that refers to SportTeam entity.
        public int SportId { get; set; }
        public int TeamId { get; set; }
    
        public SportTeam SportTeam { get; set; };
    }
