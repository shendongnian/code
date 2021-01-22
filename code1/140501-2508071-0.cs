    class Instellingen
    {
        public int ID { get; set; };
    }
    interface IHasInstellingen
    {
        Instellingen Instellingen { get; set; }
    }
    class MyLabel: Label, IHasInstellingen
    {
        public Instellingen Instellingen { get; set; }
    }
    class MyButton: Button, IHasInstellingen
    {
        public Instellingen Instellingen { get; set; }
    }
    class AnotherClass
    {
        public AnotherClass ()
        {
            GetInstellingenFromClass(new MyLabel());
            GetInstellingenFromClass(new MyButton());
            // ...
        }
        private void GetInstellingenFromClass(IHasInstellingenc)
        {
            Console.WriteLine( c.Instellingen.ID );
            // ... Do something with Instellingen
        }
    }
