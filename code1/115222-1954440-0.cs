    enum MyPersonEnum
    {
      STUDENT, // implicit 1
      TEACHER, // implicit 2
      DIRECTOR = 10 // explicit 10
    }
...
    Assert.AreEqual(1, (int)MyPersonEnum.STUDENT);
    Assert.AreEqual("STUDENT", MyPersonEnum.STUDENT.ToString());
