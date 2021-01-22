    using Skynet.Core
    
    public class when_initializing_core_module
    {
        ISkynetMasterController _skynet;
    
        public void establish_context()
        {
            //we'll stub it...you know...just in case
            _skynet = new MockRepository.GenerateStub<ISkynetMasterController>();
            _skynet.Initialize();
        }
    
        public void it_should_not_become_self_aware()
        {
            _skynet.AssertWasNotCalled(x => x.InitializeAutonomousExecutionMode());
        }
    
        public void it_should_default_to_human_friendly_mode()
        {
            _skynet.AssessHumans().ShouldEqual(RelationshipTypes.Friendly);
        }
    }
    
    public class when_attempting_to_wage_war_on_humans
    {
        ISkynetMasterController _skynet;
        public void establish_context()
        {
            _skynet = new MockRepository.GenerateStub<ISkynetMasterController>();
            _skynet.Stub(x => 
                x.DeployRobotArmy(TargetTypes.Humans)).Throws<OperationInvalidException>();
        }
    
        public void because()
        {
            _skynet.DeployRobotArmy(TargetTypes.Humans);
        }
    
        public void it_should_not_allow_the_operation_to_succeed()
        {
            _skynet.AssertWasThrown<OperationInvalidException>();
        }
    }
