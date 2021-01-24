    var list = _db.AspNetUserRoles.Where(w => w.UserId == uId)
                {
                    Uname = w.AspNetUser.UserName,
                    Name = w.AspNetRole.Name
                });
    
                dataGridView1.DataSource = list;
