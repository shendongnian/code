            List<DepartMent> depList = new List<DepartMent>();
            depList.Add(new DepartMent { DepartmentId = 1, DepartmentName = "Finance" });
            depList.Add(new DepartMent { DepartmentId = 2, DepartmentName = "HR" });
            depList.Add(new DepartMent { DepartmentId = 3, DepartmentName = "IT" });
            depList.Add(new DepartMent { DepartmentId = 4, DepartmentName = "Admin" });
            var result = from b in depList
                         select new {Id=b.DepartmentId,Damartment=b.DepartmentName,Foo="bar" };
