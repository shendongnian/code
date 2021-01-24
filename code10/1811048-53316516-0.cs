    List<Object> addMembers = new List<Object>();
     
    foreach (object nestedGroup in member)
    {
       // ...        
           foreach (object NestedGroupMember in NestedGroupMemberResult.Properties["member"])
            {
                addMembers.Add(NestedGroupMember.ToString());
                //...
            }
        }
        // ...
    }
    addMembers.ForEach(member.Add);
