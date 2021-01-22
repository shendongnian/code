    static string JoinOr(string[] values) {
        switch (values.Length) {
            case 0: return "";
            case 1: return values[0];
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < values.Length - 2; i++) {
            sb.Append(values[i]).Append(", ");
        }
        return sb.Append(values[values.Length-2]).Append(" or ")
            .Append(values[values.Length-1]).ToString();
    }
