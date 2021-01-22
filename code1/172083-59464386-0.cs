    public IEnumerable<Friend> FindFriends()
    {
        return userExists ? doc.Descendants("user").Select(user => new Friend
            {
                ID = user.Element("id").Value,
                Name = user.Element("name").Value,
                URL = user.Element("url").Value,
                Photo = user.Element("photo").Value
            }): new List<Friend>();
    }
