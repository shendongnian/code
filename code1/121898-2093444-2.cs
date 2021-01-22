        var data = new Dictionary<Parameter, string>();
        Parameter p;
        data.Add((p = new Parameter(Guid.NewGuid(), Guid.NewGuid(), "abc",
            SchemaElementType.A)), "def");
        var dv = new DefaultValue(data);
        string val1 = dv.GetParameterValue("abc"); // returns "def"
        p.ParamGuid = Guid.NewGuid();
        string val2 = dv.GetParameterValue("abc"); // BOOM
