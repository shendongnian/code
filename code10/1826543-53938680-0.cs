         var notes = (from u in db.CustomerNotes
                           join em in db.Employee on u.StaffId equals em.EmployeeId
                           where u.CustomerId == CheckIfIdCardExist.CustomerId
                           select new {
                                         Date = u.NoteDate,
                                         notes = u.Notes,
                                         employee = em.FirstName + " " + em.LastName
                                     });
         StringBuilder sb = new StringBuilder();
         foreach(var n in notes)
         {
            sb.AppendFormat(template, n.Date, n.notes, n.employee);
            sb.Append("\n");
         }
         richTextBox1.Text = sb.ToString();
