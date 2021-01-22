    class CarResource
    {
        public string Color { get; private set; }
        internal virtual void ReadFrom(XmlReader xml)
        {
            this.Color = xml.GetAttribute("colour");
        }
    }
    class RaceCarResource : CarResource
    {
        public string Sponsor { get; private set; }
        internal override void ReadFrom(XmlReader xml)
        {
            base.ReadFrom(xml);
            this.Sponsor = xml.GetAttribute("name-on-adverts");
        }
    }
    class SuperDuperUltraRaceCarResource : RaceCarResource
    {
        public string Super { get; private set; }
        internal override void ReadFrom(XmlReader xml)
        {
            base.ReadFrom(xml);
            this.Super = xml.GetAttribute("soup");
        }
    }
    class CarResourceFactory
    {
        public CarResource Read(XmlReader xml)
        {
            CarResource car;
            
            switch (xml.LocalName)
            {
                case "ordinary-car": car = new CarResource(); break;
                case "racecar": car = new RaceCarResource(); break;
                case "super_duper": car = new SuperDuperUltraRaceCarResource(); break;
                default: throw new XmlException();
            }
            
            XmlReader sub = xml.ReadSubtree();
            
            car.ReadFrom(sub);
            sub.Close();
            
            return car;
        }
    }
