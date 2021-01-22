    using System;
    class main : IPrint
    {
        public static void Main(string[] args)
        {
             P p = new P(new main());
             DataBase db = new DataBase();
             db.Add((byte)65);
             db.Add((short)66);
             db.Add((int)67);
             db.Add((long)68);
             db.Add((uint)69);
             db.Add((ushort)70);
             db.Add((ulong)71);
             db.Add(4.2D);
             db.Add(4.3F);
             db.Add(4.4M);
             db.Add('a');
             db.Add(true);
             db.Add(false);
             db.Add("Hi");
             db.Add(null);
             db.Scan(p.handler);
        }
    
        main() {}
        public void print(string s) {
             Console.WriteLine(s);
       }
    }
