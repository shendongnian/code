    using System;
    using Demo;
    
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Type type = Type.GetType("Harvester.Google.GoogleHarvester");
                IHarvester harvester = (IHarvester)Activator.CreateInstance(type);
    
                Console.WriteLine(harvester.Blah);
                Console.Read();
            }
        }
    
        public interface IHarvester
        {
            string Blah { get; }
        }
    }
    
    namespace Harvester.Google
    {
        public class GoogleHarvester : IHarvester
        {
            #region IHarvester Members
    
            public string Blah
            {
                get
                {
                    return "Google";
                }
            }
    
            #endregion
        }
    }
    
    namespace Harvester.Yahoo
    {
        public class YahooHarvester : IHarvester 
        {
            #region IHarvester Members
    
            public string Blah
            {
                get { return "Yahoo"; }
            }
    
            #endregion
        }
    }
    
    namespace Harvester.Bing
    {
        public class BingHarvester : IHarvester 
        {
            #region IHarvester Members
    
            public string Blah
            {
                get { return "Bing"; }
            }
    
            #endregion
        }
    }
