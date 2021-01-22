    static void ReverseString(string str) {
        int i = 0;
        int j = str.Length - 1;
        // what a tricky bastard!
        MethodInfo setter = typeof(string).GetMethod(
            "SetChar",
            BindingFlags.Instance | BindingFlags.NonPublic
        );
        while (i < j) {
            char temp = str[j];
            setter.Invoke(str, new object[] { j--, str[i] });
            setter.Invoke(str, new object[] { i++, temp });
        }
    }
