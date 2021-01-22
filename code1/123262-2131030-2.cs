    IOmicronDll mockWrapper = MockRepository.GenerateMock<IOmicronDll>();
    mockWrapper.Expect(wrapper => wrapper.Lock(1, ref errors)).OutRef(string.Empty).Return(true).Repeat.Any();
    mockWrapper.Expect(wrapper => wrapper.Exec(1, "sys:cfg?(type)", ref output, ref errors)).OutRef("1,CMC 56,0;", "").Return(true).Repeat.Any();
    mockWrapper.Expect(wrapper => wrapper.Exec("1", "sys:cfg?(type)", ref output, ref errors)).OutRef("1,CMC 56,0;", "").Return(true).Repeat.Any();
    Microsoft.Practices.Unity.UnityContainer c = new Microsoft.Practices.Unity.UnityContainer();
    c.RegisterInstance<IOmicronDll>(mockWrapper);
