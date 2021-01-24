        //declare a static list of a class to model
         static List<a> _results = new List<a>
                {
                    new a{
                        id:1,
                        name:'Name',
                        description:'Erika},
                     new a{
                           id:2,
                           name:'LastName',
                           description:'Conor'
                           }
            };
    //then add this ActionResult Action in controller which will return JSON Data
   
    public ActionResult ReturnJson()
                {
                    return Json(_results, JsonRequestBehavior.AllowGet);
                }
        //Best of Luck
