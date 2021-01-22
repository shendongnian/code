    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using RealEstate.Entity.Models.Base;
    
    namespace RealEstate.Models.Base
    {
        public class CityVM
        {
    
    #pragma warning disable 1591
    
            [Required]
            public string Id { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            public List<LanguageBasedName> LanguageBasedNames { get; set; }
    
            [Required]
            public string CountryId { get; set; }
    
    #pragma warning restore 1591
    
            /// <summary>
            /// Some countries do not have neither a State, nor a Province
            /// </summary>
            public string StateOrProvinceId { get; set; }
        }
    }
