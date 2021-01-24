    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        public class World
        {
            public List<ICity> Cities { get; set; }
            public List<IRegion> Regions { get; set; }
    
            public List<IRoadSystem> RoadSystems { get; set; }
            public List<ITrafficSystem> TrafficSystems { get; set; }
            //any other systems you like
    
            public void AddRoadSystemToCity(IRoadSystem system, ICity city)
            {
            }
    
            public IRoadSystem GetRoadSystem(ICity city) //or any other rule we would like to use later
            {
                throw new NotImplementedException();
            }
        }
    
        public interface IRegion
        {
        }
    
        public interface ITrafficSystem
        {
        }
    
        public interface IRoadSystem
        {
        }
    
        public interface ICity
        {
        }
    }
