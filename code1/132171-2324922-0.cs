    public class DTO
    {
        public bool IsLinked { get; set; }
    }
    public IList<DTO> Get(string _name)
    {
        return Session.Linq<Vehicle>()
                .Select(v => new DTO
                                 {
                                     IsLinked = v.Applications.Any(a => a.Name == _name)
                                 })
                .ToList();
    }
