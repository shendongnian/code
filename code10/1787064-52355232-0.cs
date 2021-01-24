 
    class Program
    {
        static void Main(string[] args)
        {
            Narys p = new Narys();
            List<Narys> nariai = p.DuomenuSkaitymas();
            p.DuomenuIrasymas(nariai);
        }
    }
