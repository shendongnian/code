    var getid = (from user in db.tables
                where user.name == tbusername.Text && user.password == tbpassword.Text
                select user.Id).FirstOrDefault();
    // or
    var getid = db.tables.Where(user => user.name == tbusername.Text && user.password == tbpassword.Text)
                         .Select(user => user.Id)
                         .FirstOrDefault();
    if(getid == null)
    {
        MessageBox.Show("Oh nooez!!!");
        return;
    }
    MessageBox.Show("You is id : " + getid );
