    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using ST = System.Threading;
    /// <summary>
    /// Provides interlocked methods for uint and ulong via IL-generation.
    /// </summary>
    public static class InterlockedUs
    {
        /// <summary>
        /// Compares two 32-bit unsigned integers for equality and, if they are equal,
        /// replaces one of the values.
        /// </summary>
        /// <param name="location">
        /// The value to exchange, i.e. the value that is compared with <paramref name="comparand"/> and
        /// possibly replaced with <paramref name="value"/>.</param>
        /// <param name="value">
        /// The value that replaces the <paramref name="location"/> value if the comparison
        /// results in equality.</param>
        /// <param name="comparand">
        /// A value to compare against the value at <paramref name="location"/>.</param>
        /// <returns>The original value in <paramref name="location"/>.</returns>
        public static uint CompareExchange(ref uint location, uint value, uint comparand)
        {
            return ceDelegate32(ref location, value, comparand);
        }
        /// <summary>
        /// Compares two 64-bit unsigned integers for equality and, if they are equal,
        /// replaces one of the values.
        /// </summary>
        /// <param name="location">
        /// The value to exchange, i.e. the value that is compared with <paramref name="comparand"/> and
        /// possibly replaced with <paramref name="value"/>.</param>
        /// <param name="value">
        /// The value that replaces the <paramref name="location"/> value if the comparison
        /// results in equality.</param>
        /// <param name="comparand">
        /// A value to compare against the value at <paramref name="location"/>.</param>
        /// <returns>The original value in <paramref name="location"/>.</returns>
        public static ulong CompareExchange(ref ulong location, ulong value, ulong comparand)
        {
            return ceDelegate64(ref location, value, comparand);
        }
        #region ---  private  ---
        /// <summary>
        /// The CompareExchange signature for uint.
        /// </summary>
        private delegate uint Delegate32(ref uint location, uint value, uint comparand);
        /// <summary>
        /// The CompareExchange signature for ulong.
        /// </summary>
        private delegate ulong Delegate64(ref ulong location, ulong value, ulong comparand);
        /// <summary>
        /// IL-generated CompareExchange method for uint.
        /// </summary>
        private static readonly Delegate32 ceDelegate32 = GenerateCEMethod32();
        /// <summary>
        /// IL-generated CompareExchange method for ulong.
        /// </summary>
        private static readonly Delegate64 ceDelegate64 = GenerateCEMethod64();
        private static Delegate32 GenerateCEMethod32()
        {
            const string name = "CompareExchange";
            Type signedType = typeof(int), unsignedType = typeof(uint);
            var dm = new DynamicMethod(name, unsignedType, new[] { unsignedType.MakeByRefType(), unsignedType, unsignedType });
            var ilGen = dm.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(
                OpCodes.Call,
                typeof(ST.Interlocked).GetMethod(name, BindingFlags.Public | BindingFlags.Static,
                    null, new[] { signedType.MakeByRefType(), signedType, signedType }, null));
            ilGen.Emit(OpCodes.Ret);
            return (Delegate32)dm.CreateDelegate(typeof(Delegate32));
        }
        private static Delegate64 GenerateCEMethod64()
        {
            const string name = "CompareExchange";
            Type signedType = typeof(long), unsignedType = typeof(ulong);
            var dm = new DynamicMethod(name, unsignedType, new[] { unsignedType.MakeByRefType(), unsignedType, unsignedType });
            var ilGen = dm.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(
                OpCodes.Call,
                typeof(ST.Interlocked).GetMethod(name, BindingFlags.Public | BindingFlags.Static,
                    null, new[] { signedType.MakeByRefType(), signedType, signedType }, null));
            ilGen.Emit(OpCodes.Ret);
            return (Delegate64)dm.CreateDelegate(typeof(Delegate64));
        }
        #endregion
    }
