    class Shipment
    {
         private string textUnloadingTimeEnd = ...;
         public DateTime UnloadingTime
         {
              get {return DateTime.Parse(textUnloadingTimeEnd); }
         }
    }
