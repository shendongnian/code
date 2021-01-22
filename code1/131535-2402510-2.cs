        public class Group
        {
            public string Id { get; set; }
            IEnumerable<Question> Questions { get; set; }
            IEnumerable<Group> Groups { get; set; }
            public static IEnumerable<Group> Extract(XElement groupElement)
            {
                var groups = new List<Group>();
                var group = new Group{ Id = groupElement.Attribute("id").Value};
                groups.Add(group);
                // Extract questions.
                var questionsSubRoot = groupElement.Element("questions");
                if (questionsSubRoot != null)
                    group.Questions = Question.Extract(questionsSubRoot);
                
                // Extract subgroups.
                var groupsElement = groupElement.Element("groups");
                if (groupsElement != null)
                    group.Groups = groupsElement.Elements("group").SelectMany(elem => Group.Extract(elem));
                
                return groups;
            }
        }
