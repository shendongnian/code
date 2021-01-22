    public class DayOfWeekComboBoxItem
    {
       public string Day{get;set;}
       public DayOfWeek DayOfWeek{get;set;}
       
       public override ToString()
       {
          return this.Date;
       }
    }
