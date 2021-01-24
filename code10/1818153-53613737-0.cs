    [Test]
    public void Test_Should_Work()
    {
            var commands = new List<ICommand>();
            var mockDispatcher = Container.Instance.RegisterMock<ICommandBus>();
            mockDispatcher.Setup(x => x.Dispatch(It.IsAny<IList<UpdateCommand>>())).Throws(new Exception("Some Error"));
        
            var commandBus = SportsContainer.Resolve<ICommandBus>();
            var commandslist = new List<UpdateScheduleCommand>()
            {
                new UpdateCommand(),
                new UpdateCommand()
            };
            //first call is working 
            //commandBus.Dispatch<UpdateScheduleCommand>(commandslist[0]);
            //its Working now.
            commandBus.Dispatch(commandslist);
    }
