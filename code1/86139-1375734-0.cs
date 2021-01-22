       [Fact]
       public void CtorArgTestResolveAtGet()
       {
           IKernel kernel = new StandardKernel();
           kernel.Bind<IWarrior>().To<Samurai>();
           var warrior = kernel.Get<IWarrior>( new ConstructorArgument( "weapon", new Sword() ) );
           Assert.IsType<Sword>( warrior.Weapon );
       }
       [Fact]
       public void CtorArgTestResolveAtBind()
       {
           IKernel kernel = new StandardKernel();
           kernel.Bind<IWarrior>().To<Samurai>().WithConstructorArgument("weapon", new Sword() );
           var warrior = kernel.Get<IWarrior>();
           Assert.IsType<Sword>( warrior.Weapon );
       }
