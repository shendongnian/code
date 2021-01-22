    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    using AutoMapper;
    
    namespace Automapping
    {
        public class AutoMappingTypePairing
        {
            public Type SourceType { get; set; }
            public Type DestinationType { get; set; }
        }
    
        public class AutoMappingAttribute : Attribute 
        {
            public Type SourceType { get; private set; }
    
            public AutoMappingAttribute(Type sourceType)
            {
                if (sourceType == null) throw new ArgumentNullException("sourceType");
                SourceType = sourceType; 
            }
        }
    
        public static class AutoMappingEngine
        {
            public static void CreateMappings(Assembly a)
            {
                IList<AutoMappingTypePairing> autoMappingTypePairingList = new List<AutoMappingTypePairing>();
    
                foreach (Type t in a.GetTypes())
                {
                    var amba = t.GetCustomAttributes(typeof(AutoMappingAttribute), true).OfType<AutoMappingAttribute>().FirstOrDefault();
    
                    if (amba != null)
                    {
                        autoMappingTypePairingList.Add(new AutoMappingTypePairing{ SourceType = amba.SourceType, DestinationType = t});
                    }
                } 
                
                foreach (AutoMappingTypePairing mappingPair in autoMappingTypePairingList) 
                {
                    Mapper.CreateMap(mappingPair.SourceType, mappingPair.DestinationType);
                }
            }
        }
    }
