    public ViewResult Hello(string userName) //note this variable is exactly what is the name of text input on page
            {
                //simple example, take input and pass back out
                TempData["Message"] = "Hello, " + userName;
                return View("Index",TempData);
            }
