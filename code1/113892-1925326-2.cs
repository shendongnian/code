    using System;
    public class BronzeShuriken : IShuriken
    {
        public void Pierce()
        {
            Console.WriteLine("Bronze shuriken pierce time now!");
        }
        public void Kill()
        {
            Console.WriteLine("Bronze shuriken kill!!!");
        }
    }
    public class RustySword : ISword
    {
        public void Slice()
        {
            Console.WriteLine("Rusty sword slice time now!");
        }
        public void Kill()
        {
            Console.WriteLine("Rusty sword kill!!!");
        }
    }
