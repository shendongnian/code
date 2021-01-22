    using System.Collections.Generic;
    using System.Web.Mvc;
    using MvcApplication1.Models;
    
    namespace MvcApplication1.Controllers
    {
    
        public class HomeController : Controller
        {
    
            public ActionResult Index()
            {
                List<Student> students = new List<Student>();
                
                // Fill with dummy data for test.
                students.Add(new Student
                {
                    Id = 1,
                    FirstName = "X",
                    LastName = "X",
                    Age = 20
                });
    
                students.Add(new Student
                {
                    Id = 2,
                    FirstName = "Y",
                    LastName = "Y",
                    Age = 30
                });
    
                return View(students);
            }
    
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Index(int[] id, string[] firstName, string[] lastName, int[] age)
            {
                List<Student> students = new List<Student>();
    
                for (int i = 0; i < id.Length; i++)
                {
                    students.Add(new Student
                    {
                        Id = id[i],
                        FirstName = firstName[i],
                        LastName = lastName[i],
                        Age  = age[i]
                    });
                }
    
                return View("Shows", students);
            }
    
        }
    
    }
