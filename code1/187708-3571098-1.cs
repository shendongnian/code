    public UserModel Save(UserModel user)
    {
        UserModel result = null;
        using (ITransaction transaction = session.BeginTransaction())
        {
            var id = session.Save(user);
            //here i expect a proxied UserModel will returned
            result = session.Get<UserModel>(id);
            transaction.Commit();
        }
        return result;
    }
