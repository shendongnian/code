        public ActionResult ActionMethod()
        {
            var toDoIds = (List<int>)Session["ToDoIds"];
            var doneIds = (List<int>)Session["DoneIds"];
            var viewModel = new ToDoViewModel();
            viewModel.DoneList.AddRange(doneIds);
            viewModel.ToDoList.AddRange(toDoIds);
            viewModel.Ktos = GetFromDbSomehow();
            return View(viewModel);
        }
