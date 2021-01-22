    using StructureMap.AutoMocking;
    namespace Foo.Business.UnitTests
    {
    	public class MainPresenterTests
    	{
    		public class When_asked_to_add_an_account
    		{
    			private IAccountService _accountService;
    			private IAccount _account;
    			private MainPresenter _mainPresenter;
    			[SetUp]
    			public void BeforeEachTest()
    			{
    				var mocker = new RhinoAutoMocker<MainPresenter>();
    				_mainPresenter = mocker.ClassUnderTest;
    				_accountService = mocker.Get<IAccountService>();
    				_account = MockRepository.GenerateStub<IAccount>();
    			}
    			[TearDown]
    			public void AfterEachTest()
    			{
    				_accountService.VerifyAllExpectations();
    			}
    			[Test]
    			public void Should_use_the_AccountService_to_create_an_account()
    			{
    				_accountService.Expect(x => x.Create()).Return(_account);
    				_mainPresenter.AddAccount();
    			}
    		}
    	}
    }
