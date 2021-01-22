    IList objList = new List<string>();
    foreach ( PropertyInfo prop in _car.GetType().GetProperties() )
    {
        var value = prop.GetValue( _car, null );
        objList.Add( value != null ? value.ToString() : null );
    }
    objArray[i] = objList;
