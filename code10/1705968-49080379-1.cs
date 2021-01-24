    string query = "SELECT title, `first name`, surname FROM `STUDENT REGISTER`";
    List<StudentViewModel> model = new List<StudentViewModel>();
    
    using (MySqlCommand cmd = new MySqlCommand(query)) {
        cmd.Connection = con;
        con.Open();
        using (MySqlDataReader sdr = cmd.ExecuteReader())
        {
            while (sdr.Read())
            {
                model.Add(new StudentViewModel
                {
                    Id = Convert.ToInt32(sdr["StudentNumber"]),
                    Title = Convert.ToString(sdr["title"]),
                    Name = Convert.ToString(sdr["first name"]),
                    Surname = Convert.ToString(sdr["surname"])
                });
            }
        }
        con.Close();
    }
    return View(model);
