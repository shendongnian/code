    XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(xmldoc);
            var query = from d in xdoc.Root.Descendants("Employee")
                        select d;
            List<Employee> lsEmp = new List<Employee>();
            foreach (var q in query)
            {
                Employee obj = new Employee();
                obj.Id = Convert.ToInt32(q.Element("Id").Value);
                obj.name = q.Element("name").Value;
                obj.Department = new Department()
                {
                    DeptName = q.Element("Department").Element("name").Value,
                    DeptId = 
                   Convert.ToInt32(q.Element("Department").Element("age").Value)
                };
                obj.Dependents = new List<Dependents>();
                
                foreach (var e in q.Element("Dependents").Elements("Dependent"))
                {
                    var dependent = new Dependents()
                    {
                        name = e.Element("name").Value,
                        age = Convert.ToInt32(e.Element("age").Value)
                    };
                    obj.Dependents.Add(dependent);
                }
                lsEmp.Add(obj);
            }
