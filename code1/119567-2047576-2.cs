    [TestMethod]
    public void VerifyThatStudentAreEqual()
    {
        Student st1 = new Student();
        st1.ID = 20;
        st1.Name = "ligaoren";
        Student st2 = new Student();
        st2.ID = 20;
        st2.Name = "ligaoren";
        var expectedStudent = new Likeness<Student, Student>(st1);
        Assert.AreEqual(expectedStudent, st2);
    }
