    public IEnumerable<Role> Roles {
      get {
        foreach (var role in mRoles)
          yield return role;
      }
    }
