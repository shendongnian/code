    mockClient
        .Setup(ec => ec.DoWork(
            It.Is<List<IParamInterface>>(el => (el[0] as ParamClass<ParamClassA>)?.ParamData.ParamClassAVar == 123)
        )
        .Returns("123");
    mockClient
        .Setup(ec => ec.DoWork(
            It.Is<List<IParamInterface>>(el => (el[0] as ParamClass<ParamClassB>)?.ParamData.ParamClassBVar == "not 123")
        )
        .Returns("not 123");
