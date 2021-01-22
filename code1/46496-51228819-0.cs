    public class XEnum
    {
        private EnumBuilder enumBuilder;
        private int index;
        private AssemblyBuilder _ab;
        private AssemblyName _name;
        public XEnum(string enumname)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            _name = new AssemblyName("MyAssembly");
            _ab = currentDomain.DefineDynamicAssembly(
                _name, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = _ab.DefineDynamicModule("MyModule");
            enumBuilder = mb.DefineEnum(enumname, TypeAttributes.Public, typeof(int));
        }
        /// <summary>
        /// adding one string to enum
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public FieldBuilder add(string s)
        {
            FieldBuilder f = enumBuilder.DefineLiteral(s, index);
            index++;
            return f;
        }
        /// <summary>
        /// adding array to enum
        /// </summary>
        /// <param name="s"></param>
        public void addRange(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                enumBuilder.DefineLiteral(s[i], i);
            }
        }
        /// <summary>
        /// getting index 0
        /// </summary>
        /// <returns></returns>
        public object getEnum()
        {
            Type finished = enumBuilder.CreateType();
            _ab.Save(_name.Name + ".dll");
            Object o1 = Enum.Parse(finished, "0");
            return o1;
        }
        /// <summary>
        /// getting with index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public object getEnum(int i)
        {
            Type finished = enumBuilder.CreateType();
            _ab.Save(_name.Name + ".dll");
            Object o1 = Enum.Parse(finished, i.ToString());
            return o1;
        }
    }
