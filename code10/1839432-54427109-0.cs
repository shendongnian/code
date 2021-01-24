foreach (var incident in incidents.ToList())
{
    var createdDate = incident.DateCreated;
    var createdTime = createdDate.TimeOfDay;
    var index = incidents.IndexOf(indcident);
    if (createdTime > startTime && createdTime < endTime){
        incidents.Skip(index).First().DateCreated = new DateTime(2019,01,01);
    }
}
And, I'm not very familiar with `.Skip()`, but could you not just do the following instead?
foreach (var incident in incidents.ToList())
{
    var createdDate = incident.DateCreated;
    var createdTime = createdDate.TimeOfDay;
    if (createdTime > startTime && createdTime < endTime){
        incident.DateCreated = new DateTime(2019, 01, 01);
    }
}
