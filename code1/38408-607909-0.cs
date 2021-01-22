    class Flugzeug : ILuftfahrzeug
    {
        public virtual void Starten()
        {
            Console.WriteLine("Das Flugzeug startet, "+Dings());
        }
    
        protected virtual string Dings()
        {
            return "Flugzeug Dings";
        }
    }
    
    
    class Motorflugzeug : Flugzeug, ILuftfahrzeug
    {
        public override void Starten()
        {
            Console.WriteLine("Das Motorflugzeug startet, "+Dings());
        }
    
        protected override string Dings()
        {
            return "Motorflugzeug Dings";
        }
    }
