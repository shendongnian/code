    using System;
    using System.Text.RegularExpressions;
    
    namespace Utils
    {
        class DateParser
        {
            private static readonly DateTime sqlMinDate = DateTime.Parse("01/01/1753");
            private static readonly DateTime sqlMaxDate = DateTime.Parse("12/31/9999");
            private static readonly Regex todayPlusOrMinus = new Regex(@"^\s*t(\s*[\-\+]\s*\d{1,4}([dwmy])?)?\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase); // T +/- number of days
            private static readonly Regex dateWithoutSlashies = new Regex(@"^\s*(\d{6}|\d{8})\s*$", RegexOptions.Compiled); // Date in MMDDYY or MMDDYYYY format
    
            private const string DATE_FORMAT = "MM/dd/yyyy";
    
            private const string ERROR_INVALID_SQL_DATE_FORMAT = "Date must be between {0} and {1}!";
            private const string ERROR_DATE_ABOVE_MAX_FORMAT = "Date must be on or before {0}!";
            private const string ERROR_USAGE = @"Unable to determine date! Please enter a valid date as either:
    	MMDDYY
    	MMDDYYYY
    	MM/DD/YY
    	MM/DD/YYYY
    
    You may also use the following:
    	T (Today's date)
    	T + 1 (Today plus/minus a number of days)
    	T + 1w (Today plus/minus a number of weeks)
    	T + 1m (Today plus/minus a number of months)
    	T + 1y (Today plus/minus a number of years)";
    
            public static DateTime SqlMinDate
            {
                get { return sqlMinDate; }
            }
    
            public static DateTime SqlMaxDate
            {
                get { return sqlMaxDate; }
            }
    
            /// <summary>
            /// Determine if user input string can become a valid date, and if so, returns it as a short date (MM/dd/yyyy) string.
            /// </summary>
            /// <param name="dateString"></param>
            /// <returns></returns>
            public static string ParseDateToString(string dateString)
            {
                return ParseDateToString(dateString, sqlMaxDate);
            }
    
            /// <summary>
            /// Determine if user input string can become a valid date, and if so, returns it as a short date (MM/dd/yyyy) string. Date must be on or before maxDate.
            /// </summary>
            /// <param name="dateString"></param>
            /// <param name="maxDate"></param>
            /// <returns></returns>
            public static string ParseDateToString(string dateString, DateTime maxDate)
            {
                if (null == dateString || 0 == dateString.Trim().Length)
                {
                    return null;
                }
    
                dateString = dateString.ToLower();
    
                DateTime dateToReturn;
    
                if (todayPlusOrMinus.IsMatch(dateString))
                {
                    dateToReturn = DateTime.Today;
    
                    int amountToAdd;
                    string unitsToAdd;
    
                    GetAmountAndUnitsToModifyDate(dateString, out amountToAdd, out unitsToAdd);
    
                    switch (unitsToAdd)
                    {
                        case "y":
                            {
                                dateToReturn = dateToReturn.AddYears(amountToAdd);
                                break;
                            }
                        case "m":
                            {
                                dateToReturn = dateToReturn.AddMonths(amountToAdd);
                                break;
                            }
                        case "w":
                            {
                                dateToReturn = dateToReturn.AddDays(7 * amountToAdd);
                                break;
                            }
                        default:
                            {
                                dateToReturn = dateToReturn.AddDays(amountToAdd);
                                break;
                            }
                    }
                }
                else
                {
                    if (dateWithoutSlashies.IsMatch(dateString))
                    {
                        /*
                        * It was too hard to deal with 3, 4, 5, and 7 digit date strings without slashes,
                        * so I limited it to 6 (MMDDYY) or 8 (MMDDYYYY) to avoid ambiguity.
                        * For example, 12101 could be:
                        *		1/21/01 => Jan 21, 2001
                        *		12/1/01 => Dec 01, 2001
                        *		12/10/1 => Dec 10, 2001
                        * 
                        * Limiting it to 6 or 8 digits is much easier to deal with. Boo hoo if they have to
                        * enter leading zeroes.
                        */
    
                        // All should parse without problems, since we ensured it was a string of digits
                        dateString = dateString.Insert(4, "/").Insert(2, "/");
                    }
    
                    try
                    {
                        dateToReturn = DateTime.Parse(dateString);
                    }
                    catch
                    {
                        throw new FormatException(ERROR_USAGE);
                    }
                }
    
                if (IsDateSQLValid(dateToReturn))
                {
                    if (dateToReturn <= maxDate)
                    {
                        return dateToReturn.ToString(DATE_FORMAT);
                    }
    
                    throw new ApplicationException(string.Format(ERROR_DATE_ABOVE_MAX_FORMAT, maxDate.ToString(DATE_FORMAT)));
                }
    
                throw new ApplicationException(String.Format(ERROR_INVALID_SQL_DATE_FORMAT, SqlMinDate.ToString(DATE_FORMAT), SqlMaxDate.ToString(DATE_FORMAT)));
            }
    
            /// <summary>
            /// Converts a string of the form:
            /// 
            /// "T [+-] \d{1,4}[dwmy]" (spaces optional, case insensitive)
            /// 
            /// to a number of days/weeks/months/years to add/subtract from the current date.
            /// </summary>
            /// <param name="dateString"></param>
            /// <param name="amountToAdd"></param>
            /// <param name="unitsToAdd"></param>
            private static void GetAmountAndUnitsToModifyDate(string dateString, out int amountToAdd, out string unitsToAdd)
            {
                GroupCollection groups = todayPlusOrMinus.Match(dateString).Groups;
    
                amountToAdd = 0;
                unitsToAdd = "d";
    
                string amountWithPossibleUnits = groups[1].Value;
                string possibleUnits = groups[2].Value;
    
                if (null == amountWithPossibleUnits ||
                    0 == amountWithPossibleUnits.Trim().Length)
                {
                    return;
                }
    
                // Strip out the whitespace
                string stripped = Regex.Replace(amountWithPossibleUnits, @"\s", "");
    
                if (null == possibleUnits ||
                    0 == possibleUnits.Trim().Length)
                {
                    amountToAdd = Int32.Parse(stripped);
                    return;
                }
    
                // Should have a parseable integer followed by a units indicator (d/w/m/y)
                // Remove the units indicator from the end, so we have a parseable integer.
                stripped = stripped.Remove(stripped.LastIndexOf(possibleUnits));
    
                amountToAdd = Int32.Parse(stripped);
                unitsToAdd = possibleUnits;
            }
    
            public static bool IsDateSQLValid(string dt) { return IsDateSQLValid(DateTime.Parse(dt)); }
    
            /// <summary>
            /// Make sure the range of dates is valid for SQL Server
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static bool IsDateSQLValid(DateTime dt)
            {
                return (dt >= SqlMinDate && dt <= SqlMaxDate);
            }
        }
    }
