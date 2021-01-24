    public class StudentModel {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public strign Surname { get; set; }
        }
        public class MarkModel {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int SubjectId { get; set; }
            public int Mark { get; set; }
        }
        public class ResultModel
        {
        
          public StudentModel Student { get; set; }
        
          public List<MarkModel> Marks { get; set; }
        
        }
        
        public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
                //int sNumber = 1;
               var model= new ResultModel{
                  Student = new StudentModel(),
                  Marks = new List<MarkModel>();
               }
        
                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string queryStudent = "SELECT id, title, `first name`, surname FROM `STUDENT` WHERE Id=1";
                    using (MySqlCommand cmd = new MySqlCommand(queryStudent))
                    {
                        cmd.Connection = con;               
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {    
                                   model.student.Id = Convert.ToInt32(sdr["id"]),
                                   model.student.Title = sdr["title"].ToString(),
                                   model.student.Name = sdr["first name"].ToString(),
                                   model.student.Surname = sdr["surname"].ToString()                     
                            }
                        }               
                    }
        
                    string queryMarks = "SELECT Id, `StudentId`, StudentId,Mark FROM `MARK` WHERE StudentId=1";
                    using (MySqlCommand cmd = new MySqlCommand(queryMarks))
                    {
                        cmd.Connection = con;               
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                model.Marks.Add(new MarkModel
                                {
                                   Id = Convert.ToInt32(sdr["Id"]),
                                   StudentId = Convert.ToInt32(sdr["StudentId"]),
                                   StudentId = Convert.ToInt32(sdr["StudentId"]),
                                   Mark = Convert.ToInt32(sdr["Mark"]),
                                });
                            }
                        }               
                    } 
                }
        
                return View(model);
            }
