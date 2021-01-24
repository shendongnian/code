    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using SubjectAccessRequests.Models;
    
    namespace SubjectAccessRequests.Controllers
    {
        public class AttemptController : Controller
        {
        // GET: Attempt
        public ActionResult Attempt()
        {
            Attempt story = new Attempt()
            {
                BookTitle = "Seabiscuit",
                Author = "Laura Hillenbrand",
            };
    
            Attempt play = new Attempt()
            {
                BookTitle = "King Lear",
                Author = "Shakespear",
            };
           List<Attempt> books = new List<Attempt>();
    
          books.Add(story);
          books.Add(play);
          return View(books);
        }
    
       
    }
