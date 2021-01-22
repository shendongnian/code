        [Test]
        public void CanSerializeCompany()
        {
            var model = TypeModel.Create();
            model.Add(typeof(Company), false).Add(1, "Employees");
            model.Add(typeof(Employee), false).Add(1, "EmployeeName").Add(2, "Designation");
            model.CompileInPlace();
            Company comp = new Company {
                Employees = {
                    new Employee { Designation = "Boss", EmployeeName = "Fred"},
                    new Employee { Designation = "Grunt", EmployeeName = "Jo"},
                    new Employee { Designation = "Scapegoat", EmployeeName = "Alex"}}
            }, clone;
            using(var ms = new MemoryStream()) {
                model.Serialize(ms, comp);
                ms.Position = 0;
                Console.WriteLine("Bytes: " + ms.Length);
                clone = (Company) model.Deserialize(ms, null, typeof(Company));
            }
            Assert.AreEqual(3, clone.Employees.Count);
            Assert.AreEqual("Boss", clone.Employees[0].Designation);
            Assert.AreEqual("Alex", clone.Employees[2].EmployeeName);
        }
