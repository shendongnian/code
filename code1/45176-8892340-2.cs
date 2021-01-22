    var propertyDescriptors = new List<PropertyDescriptor>
    {
        new DynamicPropertyDescriptor<User, string>("First name", x => x.FirstName ),
        new DynamicPropertyDescriptor<User, string>("Last name", x => x.LastName ),
        ...
    }
    
    var users = retrieve some users
    Users = new DynamicDataGridSource<User>(users, propertyDescriptors, PropertyChangedListeningMode.Handler);
    
