    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<Narys> nariai = p.DuomenuSkaitymas();
            p.DuomenuIrasymas(nariai);
        }
    }
