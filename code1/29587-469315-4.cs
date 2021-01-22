    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Planet planetEarth = Planet.MERCURY;
    
    			double earthRadius = pEarth.Radius; // Just threw it in to show usage
    			double earthWeight = double.Parse("123");
    			double earthMass   = earthWeight / pEarth.SurfaceGravity();
    
    			foreach (Planet p in Planet.Values)
    				Console.WriteLine($"Your weight on {p} is {p.SurfaceWeight(mass)}");
    
    			Console.ReadKey();
    		}
    	}
    
    	public class Planet
    	{
    		public static readonly Planet MERCURY = new Planet("Mercury", 3.303e+23, 2.4397e6);
    		public static readonly Planet VENUS   = new Planet("Venus", 4.869e+24, 6.0518e6);
    		public static readonly Planet EARTH   = new Planet("Earth", 5.976e+24, 6.37814e6);
    		public static readonly Planet MARS    = new Planet("Mars", 6.421e+23, 3.3972e6);
    		public static readonly Planet JUPITER = new Planet("Jupiter", 1.9e+27, 7.1492e7);
    		public static readonly Planet SATURN  = new Planet("Saturn", 5.688e+26, 6.0268e7);
    		public static readonly Planet URANUS  = new Planet("Uranus", 8.686e+25, 2.5559e7);
    		public static readonly Planet NEPTUNE = new Planet("Neptune", 1.024e+26, 2.4746e7);
    		public static readonly Planet PLUTO   = new Planet("Pluto", 1.27e+22, 1.137e6);
    
    		public static IEnumerable<Planet> Values
    		{
    			get
    			{
    				yield return MERCURY;
    				yield return VENUS;
    				yield return EARTH;
    				yield return MARS;
    				yield return JUPITER;
    				yield return SATURN;
    				yield return URANUS;
    				yield return NEPTUNE;
    				yield return PLUTO;
    			}
    		}
    		public string Name   { get; private set; }
    		public double Mass   { get; private set; }
    		public double Radius { get; private set; }
    		Planet(string name, double mass, double radius) => 
                (Name, Mass, Radius) = (name, mass, radius);
  
    		// Wniversal gravitational constant  (m3 kg-1 s-2)
    		public const double G = 6.67300E-11;
    		public double SurfaceGravity()            => G * mass / (radius * radius);
    		public double SurfaceWeight(double other) => other * SurfaceGravity();
    		public override string ToString()         => name;
    	}
    }
