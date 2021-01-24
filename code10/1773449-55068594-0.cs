    public MessageError Update(T t)
        {
    /* I used this why to the the property in my last version I get the name of property by Parameter */
            var type = t.GetType();
            PropertyInfo prop = type.GetProperty("Id");
    
            var value = prop.GetValue(t);    
            List.RemoveAll(x => x.GetType().GetProperty("Id").GetValue(x) == value);
            List.Add(t);
            return new MessageError
            {
                Status = Status.Sucessful
            };
        }
