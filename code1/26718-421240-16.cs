    delegate void PartCallback(IPart part);
    class Container : IContainer{
        void IContainer.GetParts(PartCallback callback){
            foreach(IPart part in internalPartsList)
                callback(part);
        }
    }
    class AScanner : IScanner{
        void IScanner.ProcessContainer(IContainer c){
            c.GetParts(delegate(IPart part){
                if(IsTypeA(part))
                    ProcessPart(part);
            });
        }
        bool IsTypeA(IPart part){
            // determine if part is of type A
        }
    }
