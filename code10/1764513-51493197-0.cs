    [Route("api/Sample/Murugan")]
            [HttpGet]
            public string Name()
            {
                List<Student> obj = new List<Student> {
                    new Student { AttendanceStatusDes=null, AttendanceStatusId =null, StudentId =1, StudentName ="A" },
                    new Student { AttendanceStatusDes="", AttendanceStatusId =1, StudentId =2, StudentName ="B" },
                    new Student { AttendanceStatusDes="", AttendanceStatusId =2, StudentId =3, StudentName ="C" },
                    new Student { AttendanceStatusDes=null, AttendanceStatusId =null, StudentId =4, StudentName ="D" },
                };
    
                for (int Count = 0; Count < obj.Count(); Count++)
                {
                    if (obj[Count].AttendanceStatusId == null && obj[Count].AttendanceStatusDes == null)
                    {
                        obj[Count].AttendanceStatusId = 1;
                        obj[Count].AttendanceStatusDes = "Present";
                    }
                }
                return "Muruganvc";
            }
