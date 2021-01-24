    using (var db = new TestContext()) {
        // This works:
        db.Groups.Add(new Group {
            Id = 42,
        });
        db.Identities.Add(new Identity {
            Id = 666,
        });
        db.SaveChanges();
        db.Memberships.Add(new Membership { 
            GroupId = 42,
            IdentityId = 666
        });
        db.SaveChanges();
        // this explodes...
        db.Groups.Add(new Group {
            Id = 0,
        });
        db.Identities.Add(new Identity {
            Id = 0,
        });
        db.SaveChanges();
        db.Memberships.Add(new Membership { 
            GroupId = 0,
            IdentityId = 0
        });
        db.SaveChanges(); // exception here!
    }
