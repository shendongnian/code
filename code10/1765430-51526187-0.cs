        protected Bootstrapper()
        {
            RegisterMyDIStuff();
            this.Router = new RoutingState();
            resolver.RegisterConstant<IScreen>(this);
            this
                .Router
                .NavigateAndReset
                .Execute(new StartViewModel())
                .Subscribe()
                .DisposeWith(this.disposable);
        }
        /// <inheritdoc />
        public RoutingState Router { get; }
