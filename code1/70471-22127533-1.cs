        [TestMethod]
        public void Foo()
        {
            Dispatcher
               .FromThread(CreateDispatcher())
                       .Invoke(DispatcherPriority.Background, new DispatcherDelegate(() =>
            {
                _barViewModel.Command.Executed += (sender, args) => _done.Set();
                _barViewModel.Command.DoExecute();
            }));
            Assert.IsTrue(_done.WaitOne(WAIT_TIME));
        }
