        private Lua _Lua;
        public void Init()
        {
            _Lua = new Lua();
            GC.Collect();  // runs GC to expose unprotected delegates
        }
        public void TestMethodOverloads()
        {
            Init();
            _Lua.DoString("luanet.load_assembly('mscorlib')");
            _Lua.DoString("luanet.load_assembly('TestLua')");
            _Lua.DoString("TestClass=luanet.import_type('LuaInterface.Tests.TestClass')");
            _Lua.DoString("test=TestClass()");
            _Lua.DoString("test:MethodOverload()");
            _Lua.DoString("test:MethodOverload(test)");
            _Lua.DoString("test:MethodOverload(1,1,1)");
            _Lua.DoString("test:MethodOverload(2,2,i)\r\nprint(i)");
        }
