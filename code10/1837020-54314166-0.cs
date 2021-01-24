cs
foreach (var status in Enum.GetValues(typeof(SystemStatus))
{
    string key = (SystemStatus)status.MethodThatRetrievesTheThingyFromProperty();
    statusAccumulator[key] = 0;
}
However, is there a reason why you don't want to use `SystemStatus` as `TKey` and use the enum instance itself to get/set the value?
cs
Dictionary<SystemStatus, int> statusAccumulator = new Dictionary<SystemStatus, int>();
// initialize statusAccumulator with all possible system statuses
foreach (var status in Enum.GetValues(typeof(SystemStatus))
{
    statusAccumulator[(SystemStatus)status] = 0;
}
