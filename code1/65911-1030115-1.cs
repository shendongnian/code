    private static void AddEntryToList(DaysOfWeek days, DaysOfWeek match, List<string> dayList, string entryText) {
                if ((days& match) != 0) {
                    dayList.Add(entryText);
                }
            }
    
            internal static string[] EnumToArray(DaysOfWeek days) {
                List<string> verbList = new List<string>();
    
                AddEntryToList(days, HttpVerbs.Sunday, dayList, "Sunday");
                AddEntryToList(days, HttpVerbs.Monday , dayList, "Monday ");
                ...
    
                return dayList.ToArray();
            }
