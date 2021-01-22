    interface IParent
    {
         void AddSection(string group, ISection section);
         IEnumerable<ISection> GetSectionsInGroup(string group);
    }
