    UnityContainer container1 = ContainerFactory.CreateContainer();
    UnityContainer container2 = ContainerFactory.CreateContainer();
    UnityContainer container3 = ContainerFactory.CreateContainer();
    MyObject1 object1 = container1.Resolve<MyObject1>();
    MyObject2 object2 = container2.Resolve<MyObject2>();
    MyObject3 object3 = container3.Resolve<MyObject3>();
