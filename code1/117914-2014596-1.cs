    public class CarResource
    {
        public CarResource LoadNewFromXML(string xml)
        {
            XmlSerializer ser = new XmlSerializer(this.GetType());
            object o = null;
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(xml)))
            {
                o = ser.Deserialize(ms);
            }
            return o as CarResource;
        }
    }
    public class RaceCarResource : CarResource
    {
    }
    public class SuperRaceCarResource : RaceCarResource
    { 
    }
