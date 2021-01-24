    using System.Runtime.InteropServices;
    
    namespace Shell32
    {
        [CoClass(typeof(ShellClass))]
        [Guid("286E6F1B-7113-4355-9562-96B7E9D64C54")]
        public interface Shell : IShellDispatch6
        {
        }
    }
