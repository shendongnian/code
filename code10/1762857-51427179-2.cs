    static IEnumerable<object[]> StudentsData {
        get {
            return [] {
                new object[] {
                    new StudentDto { FirstName = "Leo", Age = 22 },
                    new StudentDto { FirstName = "John" }
                }
            }
        }
    }
    
    [TestMethod]
    [DynamicData(nameof(StudentsData))]
    public void AddStudent_WithMissingFields_ShouldThrowException(StudentDto studentDto) {
        // logic to call service and do an assertion
    }
