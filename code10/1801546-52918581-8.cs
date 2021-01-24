    string _ID = "ID2";
    Type type = Type.GetType(_ID);
    Component ids = GetComponent(type);
    dynamic val = Convert.ChangeType(ids, type);
    StartCoroutine(val.StartAttack());
