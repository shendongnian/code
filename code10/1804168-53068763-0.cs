            public void addStudent()
            {
            //Get the course ID thats been selected.
            var selectedCourseID = selectedCourseList.courseID;
            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Find the course in the database.
                var course = db.tblCourses.Where(c => c.courseID == selectedCourseID).FirstOrDefault();
                //Find the student to add from the database.
                var student = db.tblStudents.Where(s => s.studentID == selectedStudentList.studentID).FirstOrDefault();
                if (checkIfExists(course, student))
                    MessageBox.Show("The student is already in the list!", "ERROR: ", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    //Add it to the coruses student list.
                    course.tblStudents.Add(student);
                    db.SaveChanges();
                    MessageBox.Show(String.Format("{0} was successfully enrolled in {1}!", student.fullName, course.name), "Student successfully added!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
