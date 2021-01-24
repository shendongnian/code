    [MapsTo(typeof(City))] [MapsFrom(typeof(City))] 
    public class CityDto : EntityDto<Int32> 
    { 
        public Int32 CountryID { get; set; }
        public virtual ICollection<CountryDto> Country { get; set; } 
        public string Name { get; set; } 
    }
