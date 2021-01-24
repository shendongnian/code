    // create comma separated list of selected courses
    var courses = string.Join(",", lstCourse.Items
                                        .Where(item=>item.Selected)
                                        .Select(s=>s.Text)
                                        .ToList()); 
    // add courses as parameter
    com.Parameters.Add("@courses", SqlDbType.NVarChar).Value = courses;
