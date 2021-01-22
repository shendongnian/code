    var done = false;
    var viewModel = new ProjectListViewModel(eventAggregatorMock.Object, moduleManagerMock.Object);
    Observable
       .FromEvent<EventArgs>(viewModel, "ModelLoaded"))
       .Take(1)
       .Subscribe(viewModel => 
           {
               Assert.IsNotNull(viewModel.Model);
               Assert.AreEqual(4, viewModel.Model.Count);
               done = true;
           });
    EnqueueConditional(() => done);
    EnqueueTestComplete();
