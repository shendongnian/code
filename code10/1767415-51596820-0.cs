    using System.Linq;
    using System.Xml.Linq;
   
...
    List<OpeningHours> openingHoursList = doc.Descendants("OpenHours").Select(x => new OpeningHours()
    {
        DayOfWeek = x.Element("DayOfWeek").Value.ToString(),
        CloseTime = x.Element("CloseTime").Value.ToString(),
        OpenTime = x.Element("OpenTime").Value.ToString()
    }).ToList();
