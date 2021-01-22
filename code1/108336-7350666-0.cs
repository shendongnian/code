    public class TimeTableService
        {
            ITimeTableDataProvider _provider = new TimeTableDataProvider();
    
            public void CreateLessonPlanner(WizardData wizardData)
            {
                using (var con = _provider.GetConnection())
                using (var trans = new TransactionScope())
                {
                    con.Open();
    
                    var weekListA = new List<Week>();
                    var weekListB = new List<Week>();
    
                    LessonPlannerCreator.CreateLessonPlanner(weekListA, weekListB, wizardData);
                   
                    _provider.DeleteLessonPlanner(wizardData.StartDate, con);
                    
                    _provider.CreateLessonPlanner(weekListA, con);
                    _provider.CreateLessonPlanner(weekListB, con);
    
                    _provider.DeleteTimeTable(TimeTable.WeekType.A, con);
                    _provider.StoreTimeTable(wizardData.LessonsWeekA.ToList<TimeTable>(), TimeTable.WeekType.A, con);
    
                    _provider.DeleteTimeTable(TimeTable.WeekType.B, con);
                    _provider.StoreTimeTable(wizardData.LessonsWeekB.ToList<TimeTable>(), TimeTable.WeekType.B, con);
    
                    trans.Complete();
                }
            }
        }
