    var list = _db.AspNetUserRoles.Where(w => w.UserId == uId)
                {
                    w.AspNetUser.UserName,
                    w.AspNetRole.Name
                });
    
                dataGridView1.DataSource = list;
