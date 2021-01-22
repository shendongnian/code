    Label label = null;
    switch (kvp.Key)
    {
        case MyEnum.Enum1:
            label = Label1;
            break;
        case MyEnum.Enum2:
            label = Label2;
            break;
    }
    label.ForeColor = kvp.Value ? Color.LimeGreen : Color.Red;
