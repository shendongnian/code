        public class ScheduleChange
        {
            public int SCHEDVARIANT_ID { get; set; }
            public int CLASS_ID { get; set; }
            public string CLASS_NAME { get; set; }
            public ObservableCollection<int> SCHEDCHANGE_ID { get; set; }
            public ObservableCollection<int> STUDTIME_ID { get; set; }
            public ObservableCollection<int> TEACHER_ID { get; set; }
            public ObservableCollection<string> TEACHER_NAME { get; set; }
            public ObservableCollection<int> SUBJECT_ID { get; set; }
            public ObservableCollection<string> SUBJECT_NAME { get; set; }
            public ObservableCollection<int> CABINET_ID { get; set; }
            public ObservableCollection<string> CABINET_NAME { get; set; }
            
            public ObservableCollection<int?> GROUP_ID { get; set; }
            public ObservableCollection<DateTime> CHANGE_DATE { get; set; }
            public ObservableCollection<string> COLOR_HEX { get; set; }
        }
