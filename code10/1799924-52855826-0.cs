    [Test]
    public void AddEmployee_WhenCalled_AddEmployeeToDatabase()
    {
        _unitOfWork.Setup(uow => uow.Employees.Add(_employee));
        _employeeBusiness = new EmployeeBusiness(_unitOfWork.Object);
        var result = _employeeBusiness.AddEmployee(_employeeDto);
        Assert.IsNotNull(result); // <---
        _unitOfWork.Verify(uow => uow.Employees.Add(_employee), Times.Once);
        _unitOfWork.Verify(uow => uow.Complete(), Times.Once);
    }
