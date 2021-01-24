csharp
public override void PostInitialize()
{
    // The hypothetical 'SweeperClass' in this example uses constructor
    // injection to obtain a IDbContextProvider instance and from there
    // get hold of a DbContext.
    //
    // As written, this code threw a null argument exception.
    var sweeperClass = IocManager.Resolve<SweeperClass>();
    // ...do stuff...
}
In this case, it was fortunately just a question of also resolving a unit of work to wrap the other object's construction.
using Abp.Domain.Uow;
public override void PostInitialize()
{
    using (IocManager.Resolve<IUnitOfWorkManager>().Begin())
    {
        var sweeperClass = IocManager.Resolve<SweeperClass>();
        // ...do stuff...
    }
}
So @koryakinp's answer gave me most of the solution and I just needed the above adjustment to get things going for my particular use case. 
