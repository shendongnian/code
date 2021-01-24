    internal static class DelegateUtils
    {
        private static readonly Type UtilsType = Type.GetType("System.Security.Cryptography.Utils");
        private static readonly Func<int, SafeHandle> CreateHashDel;
        private static readonly Action<SafeHandle, byte[], int, int> HashDataDel;
        private static readonly Func<SafeHandle, byte[]> EndHashDel;
        
        static DelegateUtils()
        {
            CreateHashDel = CreateCreateHashDelegate();
            HashDataDel = CreateHashDataDelegate();
            EndHashDel = CreateEndHashDelegate();
        }
        internal static SafeHandle CreateHash(int algid)
        {
            return CreateHashDel(algid);
        }
        internal static void HashData(SafeHandle h, byte[] data, int ibStart, int cbSize)
        {
            HashDataDel(h, data, ibStart, cbSize);
        }
        internal static byte[] EndHash(SafeHandle h)
        {
            return EndHashDel(h);
        }
        private static Func<int, SafeHandle> CreateCreateHashDelegate()
        {
            var prop = UtilsType.GetProperty("StaticProvHandle", BindingFlags.NonPublic | BindingFlags.Static);
            var createHashMethod = UtilsType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(mi => mi.Name == "CreateHash" && mi.GetParameters().Length == 2);
            var createHashDyn = new DynamicMethod("CreateHashDyn", typeof(SafeHandle), new[] { typeof(int) }, typeof(object), true);
            var ilGen = createHashDyn.GetILGenerator();
            ilGen.Emit(OpCodes.Call, prop.GetGetMethod(true));
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Call, createHashMethod);
            ilGen.Emit(OpCodes.Ret);
            var del = (Func<int, SafeHandle>)createHashDyn.CreateDelegate(typeof(Func<int, SafeHandle>));
            return del;
        }
        private static Action<SafeHandle, byte[], int, int> CreateHashDataDelegate()
        {
            var hashDataMethod = UtilsType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(mi => mi.Name == "HashData" && mi.GetParameters().Length == 4);
            var hashDataDyn = new DynamicMethod("HashDataDyn", typeof(void), new[] { typeof(SafeHandle), typeof(byte[]), typeof(int), typeof(int) }, typeof(object), true);
            var ilGen = hashDataDyn.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(OpCodes.Ldarg_3);
            ilGen.Emit(OpCodes.Call, hashDataMethod);
            ilGen.Emit(OpCodes.Ret);
            var del = (Action<SafeHandle, byte[], int, int>)hashDataDyn.CreateDelegate(typeof(Action<SafeHandle, byte[], int, int>));
            return del;
        }
        private static Func<SafeHandle, byte[]> CreateEndHashDelegate()
        {
            var endHashMethod = UtilsType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(mi => mi.Name == "EndHash" && mi.GetParameters().Length == 1);
            var endHashDyn = new DynamicMethod("EndHashDyn", typeof(byte[]), new[] { typeof(SafeHandle) }, typeof(object), true);
            var ilGen = endHashDyn.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Call, endHashMethod);
            ilGen.Emit(OpCodes.Ret);
            var del = (Func<SafeHandle, byte[]>)endHashDyn.CreateDelegate(typeof(Func<SafeHandle, byte[]>));
            return del;
        }
    }
