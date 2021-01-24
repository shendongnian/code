    private static string ParseExt(object[] Parameters) {
        var str = new List<string>();
        for (int i = 0; i < Parameters.Length; i++) {
            //str.Add(":" + i);
            str.Add("?"); // + i);
        }
        return string.Join(",", str);
    }
