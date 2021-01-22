    public class Car
    {
        [XmlElement("WheelStatus")]
        public Wheel.Status WheelStatus;
        [XmlElement("EngineStatus")]
        public Engine.Status EngineStatus;
        
        ...
    }
