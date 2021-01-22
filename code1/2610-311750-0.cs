    private void WriteMemberDescriptions(Type type)
    {
        var descriptions =
            from member in type.GetMembers()
            let attributes = member.GetAttributes<DescriptionAttribute>(true)
            let attribute = attributes.FirstOrDefault()
            where attribute != null
            select new
            {
                Member = member.Name,
                Text = attribute.Description
            };
            foreach(var description in descriptions)
            {
                Console.WriteLine("{0}: {1}", description.Member, description.Text);
            }
    }
