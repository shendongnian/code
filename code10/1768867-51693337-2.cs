    using (var db = new forTestEntities())
    {
        var newCondition = new tblCondition
        {
            Lower = Convert.ToInt32(textBox1.Text),
            Upper = Convert.ToInt32(textBox3.Text)
        };
        var range = Enumerable.Range(newCondition.Lower, newCondition.Upper
                                                                 - newCondition.Lower + 1);
        var check = db.tblConditions.AsEnumerable().Any(c => range
                    .Intersect(Enumerable.Range(c.Lower, c.Upper - c.Lower + 1)).Any());
        if (!check)
        {
            db.tblConditions.Add(newCondition);
            db.SaveChanges();
        }
    }
