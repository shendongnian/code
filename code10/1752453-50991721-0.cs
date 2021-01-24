	[TestFixture]
	public class ProcessStateMachineTests : InMemoryTestFixture
	{
		TimeSpan _TestTimeout = new TimeSpan(0, 1, 0);
		ProcessStateMachine _Machine;
		InMemorySagaRepository<Process> _Repository;
		protected override void ConfigureInMemoryReceiveEndpoint(
			IInMemoryReceiveEndpointConfigurator configurator)
		{
			_Machine = new ProcessStateMachine();
			_Repository = new InMemorySagaRepository<Process>();
			configurator.StateMachineSaga(_Machine, _Repository);
		}
		[OneTimeSetUp]
		public void ConfigureMessages()
		{
			// Message correlation and such happens in here
			ProcessStateMachine.ConfigureMessages();
		}
		[Test]
		public async Task OnInitializationIStartProcessIsConsumed()
		{
			var sagaId = Guid.NewGuid();
			var customerId = Guid.NewGuid();
			await SetupStateMachine(sagaId, customerId, _Machine.AwaitingDetails.Name);
			var msg = InMemoryTestHarness.Consumed
				.Select<IStartProcess>(x => x.Context.Message.RequestId == sagaId)
				.FirstOrDefault();
			// Assert against msg for expected results
		}
		[Test]
		public async Task OnStartProcessAddCustomerNoteAndRequestDetailsPublished()
		{
			var sagaId = Guid.NewGuid();
			var customerId = Guid.NewGuid();
			await SetupStateMachine(sagaId, customerId, _Machine.AwaitingDetails.Name);
			var pubdNoteAddedMsg = InMemoryTestHarness.Published
				.Select<IAddCustomerNote>()
				.FirstOrDefault(x => x.Context.Message.RequestId == sagaId);
			var pubdDetailsReqdMsg = InMemoryTestHarness.Published
				.Select<IRequestDetails>()
				.FirstOrDefault(x => x.Context.Message.RequestId == sagaId);
			Assert.IsTrue(pubdNoteAddedMsg != null);
			Assert.IsTrue(pubdDetailsReqdMsg != null);
			Assert.AreEqual(sagaId, pubdNoteAddedMsg.Context.CorrelationId);
			Assert.AreEqual(sagaId, pubdDetailsReqdMsg.Context.CorrelationId);
			Assert.AreEqual(customerId, pubdNoteAddedMsg.Context.Message.CustomerId);
			Assert.IsFalse(String.IsNullOrEmpty(pubdNoteAddedMsg.Context.Message.Note));
		}
		private async Task SetupStateMachine(
			Guid sagaId,
			Guid customerId,
			String toState)
		{
			if (String.IsNullOrEmpty(toState))
				return;
			await MoveStateMachineForward(BuildStartMessage(), x => x.AwaitingDetails);
			var awaitingDetailsId = await _Repository.ShouldContainSagaInState(
				sagaId, _Machine, x => x.AwaitingDetails, _TestTimeout);
			Assert.IsNotNull(awaitingDetailsId, "Error, expected state machine in AwaitingDetails state");
			if (toState == _Machine.AwaitingDetails.Name)
				return;
			// ...and more stuff to move to later states, depending on
			// where I want my test's starting point to be...
			async Task MoveStateMachineForward<T>(
				T message,
				Func<ProcessStateMachine, Automatonymous.State> targetState)
				where T : class
			{
				await InputQueueSendEndpoint.Send(message);
				var foundSagaId = await _Repository.ShouldContainSagaInState(
					sagaId, _Machine, targetState, _TestTimeout);
				Assert.IsTrue(foundSagaId.HasValue);
			}
			IStartProcess BuildStartMessage()
			{
				return new StartProcessMessage(sagaId, customerId);
			}
		}
	}
