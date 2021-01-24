    namespace CRDM.Core.Models
    {
        using CRDM.Core.Abstractions.Entities;
    
        [Table("cities")]
        public class City : ICity
        {
            public CountryState StateReference { get; set; }
            ICountryState ICity.StateReference
            {
                get
                {
                    return StateReference;
                }
                set
                {
                    StateReference = (CountryState)value;
                }
            }
        }
    
        [Table("country_states")]
        public class CountryState : ICountryState
        {
            public Country Country { get; set; }
            ICountry ICountryState.Country
            {
                get
                {
                    return Country;
                }
                set
                {
                    Country = (Country)value;
                }
            }
        }
    
        [Table("countries")]
        public class Country : ICountry
        {
        }
    }
    
    namespace CRDM.Core.Abstractions.Entities
    {
        public interface ICity
        {
            ICountryState StateReference { get; set; }
        }
    
        public interface ICountryState
        {
            ICountry Country { get; set; }
        }
    
        public interface ICountry
        {
        }
    }
