        // I am showing by using ASP.NET MVC, C# and Entity Framework    
        //Entity Class
            
            public class Student
                {
                    public int Id { get; set; }
                    public string Name{ get; set; }
                }
            
            //Controller Action
            
            public async Task<IActionResult> Create([Bind("Id,Name")] Student student)
                    {
                        if (ModelState.IsValid)
                        {
                            _context.Add(student);
                            await _context.SaveChangesAsync();
        
                          //Here your Id Value after insert record
                            int StudentId = student.Id;
            
                            return RedirectToAction(nameof(Index));
                        }
                        return View(student);
                    }
    //Hope you understand and it will be helpful for you.
