    public sealed class TestModule : Module
        {
    	 protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.RegisterType<DialogCreator>().As<IDialogCreator>();
                builder.RegisterType<RootDialog>().Keyed<IDialog<object>>("RootDialog");
    		}
    	}
    	
