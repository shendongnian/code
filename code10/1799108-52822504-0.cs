    ViewBag.StudentNames = new SelectList(db.Students.Select(x =>
                        new SelectListItem
                        { 
                            Value = x.ID.ToString(),
                            Text = x.StudentName
                        }),
                    "Value",
                    "Text"); 
