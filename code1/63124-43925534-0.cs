    //There is no good way to constrain a generic class parameter to an Enum.  The hack below does work at compile time,
    //  though it is convoluted.  For examples of how to use the two classes EnumIndexedArray and ObjEnumIndexedArray,
    //  see AssetClassArray below.  Or, e.g.
    //      EConstraint.EnumIndexedArray<int, YourEnum> x = new EConstraint.EnumIndexedArray<int, YourEnum>();
    //  See this post 
    //      http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum/29581813#29581813
    // and the answer/comments by Julien Lebosquain
    public class EConstraint : HackForCompileTimeConstraintOfTEnumToAnEnum<System.Enum> { }//THIS MUST BE THE ONLY IMPLEMENTATION OF THE ABSTRACT HackForCompileTimeConstraintOfTEnumToAnEnum
    public abstract class HackForCompileTimeConstraintOfTEnumToAnEnum<SystemEnum> where SystemEnum : class
    {
        //For object types T, users should use EnumIndexedObjectArray below.
        public class EnumIndexedArray<T, TEnum>
            where TEnum : struct, SystemEnum
        {
            //Needs to be public so that we can easily do things like intIndexedArray.data.sum()
            //   - just not worth writing up all the equivalent methods, and we can't inherit from T[] and guarantee proper initialization.
            //Also, note that we cannot use Length here for initialization, even if Length were defined the same as GetNumEnums up to
            //  static qualification, because we cannot use a non-static for initialization here.
            //  Since we want Length to be non-static, in keeping with other definitions of the Length property, we define the separate static
            //  GetNumEnums, and then define the non-static Length in terms of the actual size of the data array, just for clarity,
            //  safety and certainty (in case someone does something stupid like resizing data).
            public T[] data = new T[GetNumEnums()];
            //First, a couple of statics allowing easy use of the enums themselves.
            public static TEnum[] GetEnums()
            {
                return (TEnum[])Enum.GetValues(typeof(TEnum));
            }
            public TEnum[] getEnums()
            {
                return GetEnums();
            }
            //Provide a static method of getting the number of enums.  The Length property also returns this, but it is not static and cannot be use in many circumstances.
            public static int GetNumEnums()
            {
                return GetEnums().Length;
            }
            //This should always return the same as GetNumEnums, but is not static and does it in a way that guarantees consistency with the member array.
            public int Length { get { return data.Length; } }
            //public int Count  { get { return data.Length; } }
            public EnumIndexedArray() { }
            // [WDS 2015-04-17] Remove. This can be dangerous. Just force people to use EnumIndexedArray(T[] inputArray).
            // [DIM 2015-04-18] Actually, if you think about it, EnumIndexedArray(T[] inputArray) is just as dangerous:
            //   For value types, both are fine.  For object types, the latter causes each object in the input array to be referenced twice,
            //   while the former causes the single object t to be multiply referenced.  Two references to each of many is no less dangerous
            //   than 3 or more references to one. So all of these are dangerous for object types.
            //   We could remove all these ctors from this base class, and create a separate
            //         EnumIndexedValueArray<T, TEnum> : EnumIndexedArray<T, TEnum> where T: struct ...
            //   but then specializing to TEnum = AssetClass would have to be done twice below, once for value types and once
            //   for object types, with a repetition of all the property definitions.  Violating the DRY principle that much
            //   just to protect against stupid usage, clearly documented as dangerous, is not worth it IMHO.
            public EnumIndexedArray(T t)
            {
                int i = Length;
                while (--i >= 0)
                {
                    this[i] = t;
                }
            }
            public EnumIndexedArray(T[] inputArray)
            {
                if (inputArray.Length > Length)
                {
                    throw new Exception(string.Format("Length of enum-indexed array ({0}) to big. Can't be more than {1}.", inputArray.Length, Length));
                }
                Array.Copy(inputArray, data, inputArray.Length);
            }
            public EnumIndexedArray(EnumIndexedArray<T, TEnum> inputArray)
            {
                Array.Copy(inputArray.data, data, data.Length);
            }
            //Clean data access
            public T this[int ac] { get { return data[ac]; } set { data[ac] = value; } }
            public T this[TEnum ac] { get { return data[Convert.ToInt32(ac)]; } set { data[Convert.ToInt32(ac)] = value; } }
        }
        public class EnumIndexedObjectArray<T, TEnum> : EnumIndexedArray<T, TEnum>
            where TEnum : struct, SystemEnum
            where T : new()
        {
            public EnumIndexedObjectArray(bool doInitializeWithNewObjects = true)
            {
                if (doInitializeWithNewObjects)
                {
                    for (int i = Length; i > 0; this[--i] = new T()) ;
                }
            }
            // The other ctor's are dangerous for object arrays
        }
        public class EnumIndexedArrayComparator<T, TEnum> : EqualityComparer<EnumIndexedArray<T, TEnum>>
            where TEnum : struct, SystemEnum
        {
            private readonly EqualityComparer<T> elementComparer = EqualityComparer<T>.Default;
            public override bool Equals(EnumIndexedArray<T, TEnum> lhs, EnumIndexedArray<T, TEnum> rhs)
            {
                if (lhs == rhs)
                    return true;
                if (lhs == null || rhs == null)
                    return false;
                //These cases should not be possible because of the way these classes are constructed.
                // HOWEVER, the data member is public, so somebody _could_ do something stupid and make 
                // data=null, or make lhs.data == rhs.data, even though lhs!=rhs (above check)
                //On the other hand, these are just optimizations, so it won't be an issue if we reomve them anyway,
                // Unless someone does something really dumb like setting .data to null or resizing to an incorrect size,
                // in which case things will crash, but any developer who does this deserves to have it crash painfully...
                //if (lhs.data == rhs.data)
                //    return true;
                //if (lhs.data == null || rhs.data == null)
                //    return false;
                int i = lhs.Length;
                //if (rhs.Length != i)
                //    return false;
                while (--i >= 0)
                {
                    if (!elementComparer.Equals(lhs[i], rhs[i]))
                        return false;
                }
                return true;
            }
            public override int GetHashCode(EnumIndexedArray<T, TEnum> enumIndexedArray)
            {
                //This doesn't work: for two arrays ar1 and ar2, ar1.GetHashCode() != ar2.GetHashCode() even when ar1[i]==ar2[i] for all i (unless of course they are the exact same array object)
                //return engineArray.GetHashCode();
                //Code taken from comment by Jon Skeet - of course - in http://stackoverflow.com/questions/7244699/gethashcode-on-byte-array
                //31 and 17 are used commonly elsewhere, but maybe because everyone is using Skeet's post.
                //On the other hand, this is really not very critical.
                unchecked
                {
                    int hash = 17;
                    int i = enumIndexedArray.Length;
                    while (--i >= 0)
                    {
                        hash = hash * 31 + elementComparer.GetHashCode(enumIndexedArray[i]);
                    }
                    return hash;
                }
            }
        }
    }
    //Because of the above hack, this fails at compile time - as it should.  It would, otherwise, only fail at run time.
    //public class ThisShouldNotCompile : EConstraint.EnumIndexedArray<int, bool>
    //{
    //}
    //An example
    public enum AssetClass { Ir, FxFwd, Cm, Eq, FxOpt, Cr };
    public class AssetClassArrayComparator<T> : EConstraint.EnumIndexedArrayComparator<T, AssetClass> { }
    public class AssetClassIndexedArray<T> : EConstraint.EnumIndexedArray<T, AssetClass>
    {
        public AssetClassIndexedArray()
        {
        }
        public AssetClassIndexedArray(T t) : base(t)
        {
        }
        public AssetClassIndexedArray(T[] inputArray) :  base(inputArray)
        {
        }
        public AssetClassIndexedArray(EConstraint.EnumIndexedArray<T, AssetClass> inputArray) : base(inputArray)
        {
        }
        public T Cm    { get { return this[AssetClass.Cm   ]; } set { this[AssetClass.Cm   ] = value; } }
        public T FxFwd { get { return this[AssetClass.FxFwd]; } set { this[AssetClass.FxFwd] = value; } }
        public T Ir    { get { return this[AssetClass.Ir   ]; } set { this[AssetClass.Ir   ] = value; } }
        public T Eq    { get { return this[AssetClass.Eq   ]; } set { this[AssetClass.Eq   ] = value; } }
        public T FxOpt { get { return this[AssetClass.FxOpt]; } set { this[AssetClass.FxOpt] = value; } }
		public T Cr    { get { return this[AssetClass.Cr   ]; } set { this[AssetClass.Cr   ] = value; } }
    }
    //Inherit from AssetClassArray<T>, not EnumIndexedObjectArray<T, AssetClass>, so we get the benefit of the public access getters and setters above
    public class AssetClassIndexedObjectArray<T> : AssetClassIndexedArray<T> where T : new()
    {
        public AssetClassIndexedObjectArray(bool bInitializeWithNewObjects = true)
        {
            if (bInitializeWithNewObjects)
            {
                for (int i = Length; i > 0; this[--i] = new T()) ;
            }
        }
    }
