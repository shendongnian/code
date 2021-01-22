    var kernel = new StandardKernel();
    kernel.Bind<NotifiesWhenDisposed>().ToSelf();
    
    NotifiesWhenDisposed instance = null;
    using(var block = new ActivationBlock(kernel))
    {
        instance = block.Get<NotifiesWhenDisposed>();
        instance.IsDisposed.ShouldBeFalse();
    }
    
    instance.IsDisposed.ShouldBeTrue();
