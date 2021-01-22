    ForRequestedType<IBootStrapperTask>().TheDefault.Is.OfConcreteType<StartTasks>()
         .TheArrayOf<ITask>().Contains(
                y => {
                    y.OfConcreteType<Task1>();
                    y.OfConcreteType<Task2>();
                    y.OfConcreteType<Task3>();
                });
If you want to go down the route of an accepting an IEnumerable&lt;T&gt; in your constructor as far as I can see things start to become a little more complicated. You can specify and build the constructor argument like so:-
    ForRequestedType<IBootStrapperTask>().TheDefault.Is.OfConcreteType<StartTasks>()
                .CtorDependency<IEnumerable<ITask>>().Is(i => {
                    i.Is.ConstructedBy(c => {
                        return new List<ITask> { 
                               c.GetInstance<Task1>(), 
                               c.GetInstance<Task2>(), 
                               c.GetInstance<Task3>()
                        };
                    });
                });
