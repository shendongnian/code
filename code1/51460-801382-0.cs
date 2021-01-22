    class Group
    {
        List<User> members;
        void Join(User user)
        {
            members.Add(user);
        }
        void Leave(User user)
        {
            members.Remove(user);
        }
    }
