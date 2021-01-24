        public class HouseModel
    {
        public String Reference { get; set; }
        //[JsonConverter(typeof(ApplianceModelConverter))] //=> You don't need this
        public IEnumerable<IApplianceModel> Appliances { get; set; }
    }
