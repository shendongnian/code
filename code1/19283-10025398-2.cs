    class A { string Name { get; } }
    class B : A { string LongName { get; } }
    class C : A { string FullName { get; } }
    class X { public string ToString(IFormatProvider provider); }
    class Y { public string GetIdentifier(); }
    public string GetName(object value)
    {
        string name = null;
        TypeSwitch.On(operand)
            .Case((C x) => name = x.FullName)
            .Case((B x) => name = x.LongName)
            .Case((A x) => name = x.Name)
            .Case((X x) => name = x.ToString(CultureInfo.CurrentCulture))
            .Case((Y x) => name = x.GetIdentifier())
            .Default((x) => name = x.ToString());
        return name;
    }
