        [ThreadStatic]
        private static string lastMethodName = null;
        [ThreadStatic]
        private static int lastParamIndex = 0;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIfNull<T>(this T parameter)
        {
            var currentStackFrame = new StackFrame(1);
            var props = currentStackFrame.GetMethod().GetParameters();
            if (!String.IsNullOrEmpty(lastMethodName)) {
                if (currentStackFrame.GetMethod().Name != lastMethodName) {
                    lastParamIndex = 0;
                } else if (lastParamIndex >= props.Length - 1) {
                    lastParamIndex = 0;
                } else {
                    lastParamIndex++;
                }
            } else {
                lastParamIndex = 0;
            }
            if (!typeof(T).IsValueType) {
                for (int i = lastParamIndex; i &lt; props.Length; i++) {
                    if (props[i].ParameterType.IsValueType) {
                        lastParamIndex++;
                    } else {
                        break;
                    }
                }
            }
            if (parameter == null) {
                string paramName = props[lastParamIndex].Name;
                throw new ArgumentNullException(paramName);
            }
            lastMethodName = currentStackFrame.GetMethod().Name;
        }
