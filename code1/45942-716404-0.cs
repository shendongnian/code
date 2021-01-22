    public void DoSomething()
    {
        MemberInfo[] members = this.GetType().GetMembers();
        // now you can do whatever you want with each of the members,
        // including checking their .Name properties.
    }
