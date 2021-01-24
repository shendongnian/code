    public class UniversityProfessors
    {
        public static table_Professors Select(string name)
        {
            // done the job directly than declaring variable of type UniversityEntities and then do this job
            return new UniversityEntities().table_Professors.Find(name);
        }
    }
    public class UniversityStudents
    {
        public static table_Students Select(string name)
        {
            // done the job directly than declaring variable of type UniversityEntities and then do this job
            return new UniversityEntities().table_Students.Find(name);
        }
    }
    //Now in Controler call the model by Tuple and pass it to view as Tuple
    public ActionResult SabadShow()
    {
        var tuple = new Tuple<table_Professors, table_Students (Professors.Select("someValue"), Professors.Select("someValue"));
        return View(tuple);
    }
