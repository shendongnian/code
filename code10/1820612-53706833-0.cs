    public class CheckDaysViewModel 
    {
      public IEnumerable<CheckDays> CheckDays {get;set;}
      public IEnumerable<SelectListItem> CheckDaysAsSelectedList => this.CheckDays.Select(e => new SelectListItem(e.DayOfWeek, e.DayOfWeek));
      public CheckDays SelectedDay {get;set;}
    
    }
