    var list = _db.AspNetUserRoles.Where(w => w.UserId == uId).Select(w => new
                {
                    UserName = w.AspNetUser.UserName,
                    Name = w.AspNetRole.Name
                }).ToList();
    
    dataGridView1.DataSource = list;
