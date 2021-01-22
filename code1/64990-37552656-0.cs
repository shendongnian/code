    interface IMethodToHide
    {
        string MethodToHide();
    }
    class BaseWithMethodToHide : IMethodToHide
    {
        public string MethodToHide()
        {
            return "BaseWithMethodToHide";
        }
    }
    class DerivedNotImplementingInterface   : BaseWithMethodToHide
    {
        new public string MethodToHide()
        {
            return "DerivedNotImplementingInterface";
        }
    }
    class DerivedImplementingInterface : BaseWithMethodToHide, IMethodToHide
    {
        new public string MethodToHide()
        {
            return "DerivedImplementingInterface";
        }
    }
    class Program
    {
        static void Main()
        {
            var oNoI = new DerivedNotImplementingInterface();
            IMethodToHide ioNoI = new DerivedNotImplementingInterface();
            Console.WriteLine("reference to the object type DerivedNotImplementingInterface calls the method in the class " 
                + oNoI.MethodToHide());
            // calls DerivedNotImplementingInterface.MethodToHide()
            Console.WriteLine("reference to a DerivedNotImplementingInterface object via the interfce IMethodToHide calls the method in the class " 
                + ioNoI.MethodToHide());
            // calls BaseWithMethodToHide.MethodToHide()
            Console.ReadLine();
            var oI = new DerivedImplementingInterface();
            IMethodToHide ioI = new DerivedImplementingInterface();
            Console.WriteLine("reference to the object type DerivedImplementingInterface calls the method in the class " 
                + oI.MethodToHide());
            // calls DerivedImplementingInterface.MethodToHide()
            Console.WriteLine("reference to a DerivedImplementingInterface object via the interfce IMethodToHide calls the method in the class " 
                + ioI.MethodToHide());
            // calls DerivedImplementingInterface.MethodToHide()
            Console.ReadLine();
        }
    }
