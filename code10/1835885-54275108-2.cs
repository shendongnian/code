    public class Unit
    {
       public DateTime DateTime { get; set; }
       public string Model { get; set; }
       public UnitType UnitType { get; set; }
       public bool IsValid()
       {
           return Model != null && DateTime == DateTime.MinValue || UnitType != UnitType.Unknown;
        }
     }
