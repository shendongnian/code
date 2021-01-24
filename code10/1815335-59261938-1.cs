    public ActionResult Create(Information information)
    {
       var byteArray = Encoding.ASCII.GetBytes(information.FirstName + "" + information.Surname + "" + information.DOB + "" + information.Email + " " + information.Tel);
       var stream = new MemoryStream(byteArray);
            
       return File(stream, "text/plain", "your_file_name.txt");
    }
