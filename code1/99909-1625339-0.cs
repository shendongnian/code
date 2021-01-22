    public override bool Client.Equals(object obj) {        
        // The following statement is false, because the types 
        // aren't equal. obj.GetType() returns Client.DerrivedClient
        if (obj.GetType() != typeof(Client<T>))
        {
            return false;
        }
        // ...
    }
