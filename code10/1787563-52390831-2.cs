    public class AcumaticaCustomerActivityGIResults
        {
            public List<AcumaticaActivitiesGI> Result { get; set; }
        }
    
        public class AcumaticaActivitiesGI
        {
            public StringField NoteID { get; set; }
    
            public StringField CreatedByID { get; set; }
            public StringField CreatedBy { get; set; }
            public DateTimeField CreatedAt { get; set; } = new DateTimeField { value = Convert.ToDateTime("1/1/1900") };
            public StringField Owner { get; set; }
       }
    }
