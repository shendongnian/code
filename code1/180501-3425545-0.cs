       projectContact.Roles = xml.Elements() 
                                    .First() 
                                    .Elements()
                                    .ToDictionary(
                     role=> SafeConvert.ToInt32(role.Attribute("ROLE_ID").Value),
                     role=> role.Attribute("ROLE_DESC").Value)); 
 
