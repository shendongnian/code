    using (var session = RisDbHelper.OpenSession())
    {
            var tempImage = (from c in session.Query<SystemFiles>() where c.Name == "Logo" select c).FirstOrDefault();
            model.LogoImage = Convert.ToBase64String(tempImage.Data);
    }
