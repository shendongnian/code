    // get member
    var currentMember = Session.Get<Member>(SessionKey.CurrentMember);
    // set member
    Session.Set<Member>(SessionKey.CurrentMember, currentMember);
    // clear member
    Session.ClearKey(SessionKey.CurrentMember);
    // get member if in session
    if (Session.Contains(SessionKey.CurrentMember))
    {
         var current = Session.Get<Member>(SessionKey.CurrentMember);
    }
