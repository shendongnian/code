    var subject = new EditCustomerViewModel();
    using (var monitoredSubject = subject.Monitor())
    {
        subject.Foo();
        monitoredSubject.Should().Raise("NameChangedEvent");
    }
