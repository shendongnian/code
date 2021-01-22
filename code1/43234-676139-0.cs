    class MyClass:
        //a field, initialized to the value 1
        regularfield as int = 1 //default access level: protected
    
        //a string field
        mystringfield as string = "hello"
    
        //a private field
        private _privatefield as int
    
        //a public field
        public publicfield as int = 3
    
        //a static field: the value is stored in one place and shared by all
        //instances of this class
        static public staticfield as int = 4
    
        //a property (default access level: public)
        RegularProperty as int:
            get: //getter: called when you retrieve property
                return regularfield
            set: //setter: notice the special "value" variable
                regularfield = value
    
        ReadOnlyProperty as int:
            get:
                return publicfield
    
        SetOnlyProperty as int:
            set:
                publicfield = value
    
        //a field with an automatically generated property
        [Property(MyAutoProperty)]
        _mypropertyfield as int = 5
