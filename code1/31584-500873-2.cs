    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("{ ");
        stringBuilder.Append(string.Join(", ", Ad));
        stringBuilder.Append(" }");
        return stringBuilder.ToString();
    }
