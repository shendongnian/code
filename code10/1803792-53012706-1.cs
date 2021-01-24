    [TestMethod]
    public void TestNoOldEmployees_In_List()
    {
        string[] employeeIDs1 = { "EMP-01", "EMP-02", "EMP-03", "EMP-04", "EMP-05" };
        string[] employeeIDs2 = { "EMP-01", "EMP-02", "EMP-03", "EMP-04", "EMP-05"};
        var oldEmployeesCount = employeeIDs1.Where(x =>  !employeeIDs2.Contains(x)).Count();
        Assert.AreEqual(0, oldEmployeesCount);
    }
