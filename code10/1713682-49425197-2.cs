    public abstract class Sensor
    {
         private readonly string name;
         private readonly int? areaId;
         private readonly int? sensorId;
         protected Sensor(string name)
         {
             this.name = name;
         }
         protected Sensor(int areaId, int sensorId)
         {
             this.areaId = areaId;
             this.sensorId = sensorId;
         }
         public (string Name, int? AreaId, int? SensorId) Id
         {
              get
              {
                  Debug.Assert(
                      (name != null && (!areaId.HasValue && !sensorId.HasValue)) ||
                      (name == null && (areaId.HasValue && sensorId.HasValue));
                  return (name, areaId, sensorId);
              }
         }
    }
