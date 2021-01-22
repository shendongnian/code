    BaseAuto auto = kernel.Get<BaseAuto>();//Get from the NInjector kernel your object. You get your concrete objet and the object "auto" will be filled up (interface inside him) with the kernel.
    //Somewhere else:
    public class BaseModule : StandardModule
    {
            public override void Load(){
                Bind<BaseAuto>().ToSelf();
                Bind<IEngine>().To<FourCylinder>();//Bind the interface
            }     
     }
