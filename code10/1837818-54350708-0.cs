    using System.Linq;
    using System.Collections.Generic
-----------
     public IEnumerable<meter> GetMetersByAccountNumber(string accountNumber) {
        var items = new List<meter>();
        //some query work and next is sql data reader
     
        while (rdr.Read())
        {
          var deviceClass = rdr["deviceClass"].ToString();
          var meter = new meter();
          //Im guessing meter has some properties to set ?
          meter.deviceClass = deviceClass;
          items.Add(meter);
        }
        return items.AsReadOnly();
    }
