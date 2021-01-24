    public class Issue
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Accuracy")]
        public int Accuracy { get; set; }
        [JsonProperty("Icd")]
        public string Icd { get; set; }
        [JsonProperty("IcdName")]
        public string IcdName { get; set; }
        [JsonProperty("ProfName")]
        public string ProfName { get; set; }
        [JsonProperty("Ranking")]
        public int Ranking { get; set; }
    }
    public class Specialisation
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("SpecialistID")]
        public int SpecialistID { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("Issue")]
        public Issue Issue { get; set; }
        [JsonProperty("Specialisation")]
        public IList<Specialisation> Specialisation { get; set; }
    }
