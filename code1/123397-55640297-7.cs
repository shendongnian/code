        public ActionResult Index()
        {
           
            // Retrieve the person, address and comment entities and
            // map them on to a person view model entity
            var personId = 23;
 
            var person = _personTasks.GetPerson(personId);
            var address = _personTasks.GetAddress(personId);
            var comment = _personTasks.GetComment(personId);
 
            var personViewModel = EntityMapper.Map<PersonViewModel>(person, address, comment);
 
            return this.View(personViewModel);
        }
 
