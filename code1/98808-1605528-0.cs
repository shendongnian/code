    public Init() {
        deleteUserMethodsByStatus = new Dictionary<SomeEnum, Action<User>>();
        deleteUserMethodsByStatus.Add(UserStatus.Active, user => { throw new BusinessException("Cannot delete an active user."); });
        deleteUserMethodsByStatus.Add(UserStatus.InActive, DoUserDeletion});
    }
    
    //This is how you could use this dictionary
    public void DeleteUser(int userId) {
        User u = DaoFactory.User.GetById(userId);
        deleteUserMethodsByStatus[u.Status](u);
    }
    //the actual deletion process
    protected internal DoUserDeletion(User u) {
        DaoFactory.User.Delete(u);
    }
