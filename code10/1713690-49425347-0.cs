    public class namedSensorID : ISensorIdentifier
    {
        public string UniqueSensorId { get { return nameof(namedSensorID) + name; } }
        string name { get; set; }
    }
    public class idSensorID : ISensorIdentifier
    {
        int areaID { get; set; }
        int sensorID { get; set; }
        public string UniqueSensorId { get { return nameof(idSensorID) + areaID + sensorID; } }
    }
