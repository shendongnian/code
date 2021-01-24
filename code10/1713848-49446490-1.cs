    public class TeamMember
    {
        public int TeamId { get; set; }
        [JsonIgnore]
        public Team Team { get; set; }
    }
