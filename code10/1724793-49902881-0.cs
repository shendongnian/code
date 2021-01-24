            ...
            builder.Register(s => CreateViewModel(s, svc => new SomeViewModel(svc))).AsSelf();
        }
        private T CreateViewModel<T>(IComponentContext ctx, Func<SomeService, T> createInstance) {
            var svc = ctx.Resolve<SomeService>();
            var instance = createInstance(svc);
            svc.SetViewModel(instance);
            return instance;
        }
