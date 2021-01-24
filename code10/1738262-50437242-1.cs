             kernel.Bind<DepInterfaceOne>().To<DepInterfaceOneClass>().InSingletonScope();
            kernel.Bind<DepInterfaceOneTwo>().ToMethod(a =>
            {
                DepInterfaceOne toReturn = kernel.Get<DepInterfaceOne>();
                toReturn.InfoRequiredForAtRunTime(HttpContext.Current.Session["InfoRequired"]);
                return toReturn;
            });
