    class SampleProgram
    {
        static void Main(string[] args)
        {
            string xml = @"<people>
    <person><name>kumar</name><school>fes</school><parent>All</parent></person>
    <person><name>manju</name><school>fes</school><parent>kumar</parent></person>
    <person><name>anu</name><school>frank</school><parent>kumar</parent></person>
    <person><name>anitha</name><school>jss</school><parent>All</parent></person>
    <person><name>rohit</name><school>frank</school><parent>manju</parent></person>
    <person><name>anill</name><school>vijaya</school><parent>manju</parent></person>
    <person><name>vani</name><school>jss</school><parent>kumar</parent></person>
    <person><name>soumya</name><school>jss</school><parent>kumar</parent></person>
    <person><name>madhu</name><school>jss</school><parent>rohit</parent></person>
    <person><name>shiva</name><school>jss</school><parent>rohit</parent></person>
    <person><name>vanitha</name><school>jss</school><parent>anitha</parent></person>
    <person><name>anu</name><school>jss</school><parent>anitha</parent></person>
    </people>";
            XDocument document = XDocument.Parse(xml);
            var people = (from person in document.Descendants("person")
                          select new Person
                          {
                              Name = (string)person.Element("name"),
                              School = (string)person.Element("school"),
                              Parent = (string)person.Element("parent")
                          }).ToList();
            var parents = people.Where(p => p.Parent == "All");
            Action<Person> findChildren = null;
            findChildren = person =>
                {
                    List<Person> children = people.Where(p => p.Parent == person.Name).ToList();
                    person.Children = children;
                    foreach (Person p in children)
                        findChildren(p);
                };
            foreach (Person parent in parents)
            {
                findChildren(parent);
            }
            Action<Person, int> showChildren = null;
            showChildren = (person, tabs) =>
                {
                    Console.WriteLine(new string('\t', tabs) + person.Name);
                    if (person.Children != null)
                    {
                        foreach (Person p in person.Children)
                            showChildren(p, tabs + 1);
                    }
                };
            foreach (Person parent in parents)
            {
                showChildren(parent, 0);
            }
            Console.Read();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string School { get; set; }
        public string Parent { get; set; }
        public List<Person> Children { get; set; }
    }
