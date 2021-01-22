    using System;
    using System.Collections.Generic;
    namespace ScratchPad
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var p = new Program();
                p.Run();
            }
        private void Run()
        {
            double earthWeight = 175;
            double mass = earthWeight / Planet.Earth.SurfaceGravity();
            foreach (Planet planet in Enum.GetValues(typeof(Planet))) {
                Console.WriteLine("Your weight on {0} is {1}", planet, planet.SurfaceWeight(mass));
            }
        }
    }
    public enum Planet
    {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }
    public static class PlanetExtensions
    {
        private static readonly Dictionary<Planet, PlanetData> planetMap = new Dictionary<Planet, PlanetData>
          {
              {Planet.Mercury, new PlanetData(3.303e+23, 2.4397e6)},
              {Planet.Venus, new PlanetData(4.869e+24, 6.0518e6)},
              {Planet.Earth, new PlanetData(5.976e+24, 6.37814e6)},
              {Planet.Mars, new PlanetData(6.421e+23, 3.3972e6)},
              {Planet.Jupiter, new PlanetData(1.9e+27,   7.1492e7)},
              {Planet.Saturn, new PlanetData(5.688e+26, 6.0268e7)},
              {Planet.Uranus, new PlanetData(8.686e+25, 2.5559e7)},
              {Planet.Neptune, new PlanetData(1.024e+26, 2.4746e7)}
          };
        private const double G = 6.67300E-11;
        public static double Mass(this Planet planet)
        {
            return GetPlanetData(planet).Mass;
        }
        public static double Radius(this Planet planet)
        {
            return GetPlanetData(planet).Radius;
        }
        public static double SurfaceGravity(this Planet planet)
        {
            PlanetData planetData = GetPlanetData(planet);
            return G * planetData.Mass / (planetData.Radius * planetData.Radius);
        }
        public static double SurfaceWeight(this Planet planet, double mass)
        {
            return mass * SurfaceGravity(planet);
        }
        private static PlanetData GetPlanetData(Planet planet)
        {
            if (!planetMap.ContainsKey(planet))
                throw new ArgumentOutOfRangeException("planet", "Unknown Planet");
            return planetMap[planet];
        }
        #region Nested type: PlanetData
        public class PlanetData
        {            
            public PlanetData(double mass, double radius)
            {
                Mass = mass;
                Radius = radius;
            }
            public double Mass { get; private set; }
            public double Radius { get; private set; }
        }
        #endregion
        }
    }
