    GrooveMembers.GrooveMembers AddMember = new GrooveMembers.GrooveMembers();
    AddMember.GrooveRequestHeaderValue = new GrooveMembers.GrooveRequestHeader();
    AddMember.GrooveRequestHeaderValue.GrooveRequestKey = someString; //Whatever used in your envronment
    AddMember.GrooveRequestHeaderValue.GrooveIdentityURL = id.URI; //URI of the local Groove identity or the Groove Data Bridge
    AddMember.Url = someOtherString /*Local web string or remote host*/ + space.Members;//A property of the space you are inviting the tuser into
    GrooveMembers.Member[] Members = AddMember.Read();//actually connects to the service
    
    GrooveMembers.Member newMember = new GrooveMembers.Member();
    newMember.URI = userIdentity;//A string stripped from the database and TRIMmed
    newMember.Name = userFullName;//A string also pulled from the database DisplayNeme\GrooveDomain
    string userContact = "/GWS/Groove/2.0/Contacts/" + userIdentity.Replace("://", "/");
    newMember.Contact = userContact;// A string formatted by replacing :// with / adding "/GWS/Groove/2.0/Contacts/" to the front of the Groove Identity
    newMember.Role = "$Telespace.Member";
    
    AddMember.Create(newMember);
    
    GrooveMembers.GrooveMembers AddMember = new GrooveMembers.GrooveMembers();
    AddMember.GrooveRequestHeaderValue = new GrooveMembers.GrooveRequestHeader();
    AddMember.GrooveRequestHeaderValue.GrooveRequestKey = someString; //Whatever used in your envronment
    AddMember.GrooveRequestHeaderValue.GrooveIdentityURL = id.URI; //URI of the local Groove identity or the Groove Data Bridge
    AddMember.Url = someOtherString [Local web string or remote host] + space.Members [A property of the space you are inviting the tuser into];
    GrooveMembers.Member[] Members = AddMember.Read();//actually connects to the service
    
    GrooveMembers.Member newMember = new GrooveMembers.Member();
    newMember.URI = userIdentity;//A string stripped from the database and TRIMmed
    newMember.Name = userFullName;//A string also pulled from the database DisplayNeme\GrooveDomain
    string userContact = "/GWS/Groove/2.0/Contacts/" + userIdentity.Replace("://", "/");
    newMember.Contact = userContact;// A string formatted by replacing :// with / adding "/GWS/Groove/2.0/Contacts/" to the front of the Groove Identity
    newMember.Role = "$Telespace.Member";
    
    AddMember.Create(newMember);
