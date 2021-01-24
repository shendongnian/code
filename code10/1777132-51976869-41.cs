    PropertyGet, used to read the value of the property
       Pattern: <PropType> get_<PropName> (<Indices>)
       Example: System.String get_Name ();
       Example: System.Object get_Item (System.Object key);
    PropertySet, used to modify the value of the property
       Pattern: void set_<PropName> (<Indices>, <PropType>)
       Example: void set_Name (System.String name);
       Example: void set_Item (System.Object key, System.Object value); 
