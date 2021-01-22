        static Action squareIt;
        static Foo() {
            var method = new DynamicMethod(
                                           "TryItForReal",
                                           typeof(void),
                                           Type.EmptyTypes,
                                           typeof(Foo).Module);
            ILGenerator il = method.GetILGenerator();
            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Call, typeof(Foo).GetMethod("tryit"));
            il.Emit(OpCodes.Ret);
            squareIt = (Action)method.CreateDelegate(typeof(Action));
        }
        public void tryit()
        {
            if (this == null) {
                throw new InvalidOperationException("Was null");
            }
        }
        public void Bar() {
            squareIt();
        }
    }
