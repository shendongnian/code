    cmd.Parameters.Add("identity", SqlDBType.???).Value = item.Identity;
    cmd.Parameters.Add("desc", SqlDbType.???, ?size?).Value = item.Description;
    cmd.Parameters.Add("title", SqlDBType.???, ?size?).Value = item.Title;
    
    //Output params generally don't need a value so...
    cmd.Parameters.Add("someOut", SqlDBType.???).Direction = ParameterDirection.Output;
    
