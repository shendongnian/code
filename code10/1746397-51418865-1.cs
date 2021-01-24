    public FileContentResult AddEmployeeListSubmit(AddEmployeeList model)
        {
            //working with file
            _progressHandler.MaxProgress = emps.Count;
            _progressHandler.Statut = "Running";
            //working with file and insert...
            int iter = 0;
            foreach(var Employee in EmployeeList)
            {
            //make insert in db
            iter++;
            _progressHandler.Progress = iter;
            }
            _progressHandler.Statut = "Complete";
            _progressHandler.Events = Errors.ToArray();
            return something;
    }
