    [Test]
    public void SetStateExecuting_Should_Set_State_To_Pause_And_Not_Change_GlobalState_When_GlobalState_Is_Paused()
    {
        var task = new Task { ID = 1, TimeZone = -660, GlobalState = TaskState.Paused };
        _mockRepository.ReplayAll();
        _manager.SetStateExecuting(task);
        _taskDataProvider.AssertWasCalled(p => p.StateUpdate(task.ID, task.TimeZone, TaskState.Paused));
        _taskDataProvider.AssertWasNotCalled(p => p.GlobalStateUpdate(task.ID, TaskState.Executing));
        _mockRepository.ReplayAll();
    }
