    [SetUp]
    public override void Init() {
        base.Init();
        // --- Create Plan Mock
        // some code here
        // --- Create Treatment Mock
        DateTime time1 = new DateTime(2000, 01, 01, 12, 00, 00);
        DateTime time2 = new DateTime(2000, 01, 01, 13, 00, 00);
        var treatMock1 = new Treatment {
            TimeStamp = time1
        };
        var treatMock2 = new Treatment {
            TimeStamp = time2
        };
        treatGroupMock1 = new Mock<ITreatmentGroup>();
        treatGroupMock1.Setup(_ => _.Treatments).Returns(new List<ITreatment>() { treatMock1, treatMock2 });
    }
    
