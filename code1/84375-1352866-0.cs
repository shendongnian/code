    public interface Rule
    {
        bool Satisfies(Employee employee);
    }
    public class ScheduleRule : Rule
    {
        ScheduleRule(Schedule schedule)
        { ... }
        bool Satisfies(Employee employee)
        {
            // Ensure the employee is available
        }
    }
    public class HolidayRule : Rule
    {
        HolidayRule(Datetime date)
        { ... }
        bool Satisfies(Employee employee)
        {
            // Checks if the employee as volunteered for this holiday
        }
    }
