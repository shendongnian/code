            [HttpPost]
            public JsonResult InsertPatientAppointment(myType myType)
            {
    
                return new JsonResult(new
                {
                    myType.patientRegNo,
                    myType.appointmentDate
                });
            }
    
            public class myType{
                public string patientRegNo
                {
                    get;
                    set;
                }
                public string appointmentDate
                {
                    get;
                    set;
                }
            }
