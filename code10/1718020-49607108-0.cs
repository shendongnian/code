    public interface IMyAwesomeInterface
    {
        DataRow DataRow { get; set; }
    }
    
    ...
    
    public class AlarmSeverityDto : IMyAwesomeInterface
    
    ...
    
    public List<T> GetAlarmSeverityDtos<T>() where T : IMyAwesomeInterface, new()
    {
        ...
        var alarmSeverityDto = new T() { DataRow = hbrow};
                             
        resultList.Add(alarmSeverityDto);
        ...
    }
