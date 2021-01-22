    var stub = mocks.Stub<IFooLikeObject>();
    
    stub.Stub( x => x.FooLikeObject1).Return("AValidString");
    stub.Stub( x => x.FooLikeObject2).Return("AValidString2");
    stub.Stub( x => x.FooLikeObject5).Return("1");
    stub.Stub( x => x.FooLikeObject6).Return("1");
