        namespace CRDM.Core.Models
        {
            public class City : ICity<CountryState>
            {
                public CountryState StateReference { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            }
    
            public class CountryState : ICountryState<ICountry>
            {
            }
    
            public class Country : ICountry
            {
            }
        }
    
        namespace CRDM.Core.Abstractions.Entities
        {
            public interface ICity<TState> 
           
               where TState : ICountryState<ICountry>
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
