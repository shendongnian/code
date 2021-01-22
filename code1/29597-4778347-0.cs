    using System;
    using System.Reflection;
    
    class PlanetAttr: Attribute
    {
        internal PlanetAttr(double mass, double radius)
        {
            this.Mass = mass;
            this.Radius = radius;
        }
        public double Mass { get; private set; }
        public double Radius { get; private set; }
    }
    
    public static class Planets
    {
        public static double GetSurfaceGravity(this Planet p)
        {
            PlanetAttr attr = GetAttr(p);
            return G * attr.Mass / (attr.Radius * attr.Radius);
        }
    
        public static double GetSurfaceWeight(this Planet p, double otherMass)
        {
            PlanetAttr attr = GetAttr(p);
            return otherMass * p.GetSurfaceGravity();
        }
    
        public const double G = 6.67300E-11;
    
        private static PlanetAttr GetAttr(Planet p)
        {
            return (PlanetAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(PlanetAttr));
        }
    
        private static MemberInfo ForValue(Planet p)
        {
            return typeof(Planet).GetField(Enum.GetName(typeof(Planet), p));
        }
    
    }
    
    public enum Planet
    {
        [PlanetAttr(3.303e+23, 2.4397e6)]  MERCURY,
        [PlanetAttr(4.869e+24, 6.0518e6)]  VENUS,
        [PlanetAttr(5.976e+24, 6.37814e6)] EARTH,
        [PlanetAttr(6.421e+23, 3.3972e6)]  MARS,
        [PlanetAttr(1.9e+27,   7.1492e7)]  JUPITER,
        [PlanetAttr(5.688e+26, 6.0268e7)]  SATURN,
        [PlanetAttr(8.686e+25, 2.5559e7)]  URANUS,
        [PlanetAttr(1.024e+26, 2.4746e7)]  NEPTUNE,
        [PlanetAttr(1.27e+22,  1.137e6)]   PLUTO
    }
