    {1} _{0};
    internal {1} {0}
    {{
        get {{ return _{0}; }}
        set
        {{
            _{0} = value;
            UpdateRowValue(myObj, "{0}", value);
        }}
    }}
    internal void SetNull{0}()
    {{
        UpdateRowValue(myObj, "{0}", DBNull.Value);
    }}
