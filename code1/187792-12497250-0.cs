    MemberInfo[] memberInfos = typeof(MyEnum).GetMembers(BindingFlags.Public | BindingFlags.Static);
    string alerta = "";
    for (int i = 0; i < memberInfos.Length; i++) {
    alerta += memberInfos[i].Name + " - ";
    /* alerta += memberInfos[i].GetType().Name + "\n"; */ 
    // the actual enum object (of type MyEnum, above code is of type System.Reflection.RuntimeFieldInfo)
    object enumValue = memberInfos[i].GetValue(0);
    alerta += enumValue.ToString() + "\n";
    }
