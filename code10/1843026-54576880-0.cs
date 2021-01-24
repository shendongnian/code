    mockClient
        .Setup(ec => ec.DoWork(
            It.Is<List<IParamInterface>>(el => el[0] is ParamClass<ParamClassA> classA && classA.ParamData.ParamClassAVar == 123)
        )
        .Returns("123");
    mockClient
        .Setup(ec => ec.DoWork(
            It.Is<List<IParamInterface>>(el => el[0] is ParamClass<ParamClassB> classB && classB.ParamData.ParamClassBVar == "not 123")
        )
        .Returns("not 123");
