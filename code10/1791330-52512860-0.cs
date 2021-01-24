    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            Period p1 = new PeriodBuilder { Years = 3, Months = 10 }.Build();
            Period p2 = new PeriodBuilder { Years = 5, Months = -12 }.Build();
            Period sum = p1 + p2;
            Period normalized = NormalizeYearsAndMonths(sum);
            Console.WriteLine($"{normalized.Years} years; {normalized.Months} months");
        }
        
        static Period NormalizeYearsAndMonths(Period period)
        {
            // TODO: Handle negative years and months however you want.
            int years = period.Years;
            int months = period.Months;
            years += months / 12;
            months = months % 12;
            var builder = period.ToBuilder();
            builder.Years = years;
            builder.Months = months;
            return builder.Build();
        }
    }
