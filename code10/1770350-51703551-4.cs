     public ActionResult BooksCount()
    {
    ViewBag.booksGroup= db.BookPublications.GroupBy(x => x.FacultyDepartment)
           .Select(y => new BookPublicationViewModel{ FacultyDepartment = y.Key, DepartmentCount = y.Count() });
        return View();
    }
