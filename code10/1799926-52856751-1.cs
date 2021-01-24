    [Test]
    public void AddEmployee_WhenCalled_AddEmployeeToDatabase()
    {
        _unitOfWork.Setup(uow => uow.Employees.Add(_employee));
        _employeeBusiness = new EmployeeBusiness(_unitOfWork.Object);
    
        var result = _employeeBusiness.AddEmployee(_employeeDto);
    
        //_unitOfWork.Verify(uow => uow.Employees.Add(_employee), Times.Once); <-- This did not work 
        
        _unitOfWork.Verify(uow => uow.Employees.Add(It.IsAny<Employee>()), Times.Once); // <-- After changing this to It.IsAny<Employee>() it worked 
        _unitOfWork.Verify(uow => uow.Complete(), Times.Once);
    }
