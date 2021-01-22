    using System;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    
    public partial class UserDefinedFunctions
    {
        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static SqlInt32 CalculateAge(string strBirthDate)
        {
            DateTime dtBirthDate = new DateTime();
            dtBirthDate = Convert.ToDateTime(strBirthDate);
            DateTime dtToday = DateTime.Now;
    
            // get the difference in years
            int years = dtToday.Year - dtBirthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (dtToday.Month < dtBirthDate.Month || (dtToday.Month == dtBirthDate.Month && dtToday.Day < dtBirthDate.Day))
                years=years-1;
            int intCustomerAge = years;
            return intCustomerAge;
        }
    };
