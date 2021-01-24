            static void Main(string[] args)
        {
            var newList = EmployeeHelper.UpdateState(new List<FullTimeEmployee>() { new FullTimeEmployee() { FirstName = "Ryan1", FullTimeOnly = 1 } }, new FullTimeEmployee() { FirstName = "Ryan2", FullTimeOnly = 2 }, 9, "FullTimeOnly");
            var newList2 = EmployeeHelper.UpdateState(new List<PartTimeEmployee>() { new PartTimeEmployee() { FirstName = "Roy1" } }, new PartTimeEmployee() { FirstName = "Roy", PartTimeOnly = 6 }, 2, "PartTimeOnly");
        }
