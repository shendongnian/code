    class Container : IContainer{
        IEnumerable IContainer.GetParts(string type){
            foreach(IPart part in internalPartsList)
                if(part.TypeID == type)
                    yield return part;
        }
    }
    class AScanner : IScanner{
        void IScanner.ProcessContainer(IContainer c){
            foreach(IPart part in c.GetParts("A"))
                ProcessPart(part);
        }
    }
