    namespace CRDM.Core.Models
    {
    
        public class City : ICity<CountryState,Country>
        {
            public CountryState StateReference { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
    
    
        public class CountryState : ICountryState<Country>
        {
        }
    
        
        public class Country : ICountry
        {
        }
    }
    
    namespace CRDM.Core.Abstractions.Entities
    {
        public interface ICity<TState,TCountry>        
           where TCountry: ICountry
           where TState : ICountryState<TCountry>
        {
            TState StateReference { get; set; }
        }
    
        public interface ICountryState<TCountry>        
           where TCountry : ICountry
        {
    
        }
    
        public interface ICountry
        {
        }
    }
