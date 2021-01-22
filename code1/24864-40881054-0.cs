            ////  ViewModel
            public class RegisterViewModel
              {
            public RegisterViewModel()
              {
                  ActionsList = new List<SelectListItem>();
              }
            public IEnumerable<SelectListItem> ActionsList { get; set; }
            public string StudentGrade { get; set; }
               }
           //// Enum Class
            public enum GradeTypes
                 {
                   A,
                   B,
                   C,
                   D,
                   E,
                   F,
                   G,
                   H
                }
             ////Controller action 
               public ActionResult Student()
                   {
        RegisterViewModel vm = new RegisterViewModel();
        IEnumerable<GradeTypes> actionTypes = Enum.GetValues(typeof(GradeTypes))
                                             .Cast<GradeTypes>();                  
        vm.ActionsList = from action in actionTypes
                         select new SelectListItem
                         {
                             Text = action.ToString(),
                             Value = action.ToString()
                         };
                  return View(vm);
                   }
             ////// View Action
       <div class="form-group">
                                <label class="col-lg-2 control-label" for="hobies">Student Grade:</label>
                                <div class="col-lg-10">
                                   @Html.DropDownListFor(model => model.StudentGrade, Model.ActionsList, new { @class = "form-control" })
                                </div>
