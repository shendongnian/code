    public static ScheduleListExtentions
    {
        public static IEnumerable<ScheduleList> DoSomething(this IEnumerable<ScheduleList> mylist){
           //Act on your collection in some mannor here
           return mylist;
        } 
    }
