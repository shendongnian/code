        [Fact]
        public void MyServiceMethod_Should_ChangeProp_Before_Persists()
        {
            var repository = Substitute.For<IMyRepository>();
            var service = new MyService(repository);
            var myEntity = new MyEntity();
            var namePersisted = string.Empty;
            repository.Persist(Arg.Do<MyEntity>(e => namePersisted = e.MyProp));
            service.MyServiceMethod(myEntity);
            Assert.Equal(myEntity.MyProp, namePersisted);
        }
