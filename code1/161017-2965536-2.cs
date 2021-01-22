      public class JobsViewModel
      {
           [Required]
           public string FirstName { get; set; }
           [Required]
           public string LastName { get; set; }
           public int JobRole { get; set; }
           [ScaffoldColumn(false)]
           public IEnumerable<SelectListItem> JobRoleList { get; set; }
           ...
      }
      public ActionResult Submit( JobsViewModel model )
      {
           if (ModelState.IsValid)
           {
               ... convert model to entity and save to DB...
           }
           return JobsView( model );
      }
