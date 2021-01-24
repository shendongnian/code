        public class StudentObject
        {
            public int Stud_id { get; set; }
            public string Stud_name { get; set; }
        }
        [HttpGet]
        public HttpResponseMessage GetStudent(int id)
        {
            StudentObject studentObject = new StudentObject
            {
                Stud_id = 1,
                Stud_name = "test"
            };
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, studentObject);
        }
