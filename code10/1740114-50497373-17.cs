        var foo = new Foo(() => new Imp1Request<int>());
        foo.DoThingOne(1);
        foo.DoThingOne("lol"); //will throw InvalidOperationException
        foo.ChangeRequestFactory(() => new Imp1Request<string>());
        foo.DoThingOne(1);//will throw InvalidOperationException
        foo.DoThingOne("lol");
 
