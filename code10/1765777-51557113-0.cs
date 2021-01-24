    // general object is created above
    var res = (from contact in _database.OBJECTCONTACT.AsEnumerable() // as enumerable used to allow for defaultifempty in join (minor damage to performance)
                    join oGroup in _database.OBJECTGROUP on contact.OBJECTGROUPID equals oGroup.OBJECTGROUPID into og from objectGroup in og.DefaultIfEmpty(defaultValue: general)
                    where contact.OBJECTCONTACTOWNER.Any(o => o.OBJECTTYPE == type && o.OBJECTID == id)
                    // ReSharper disable once PossibleNullReferenceException (it's taken care of by check using .any() )
                    group new {contact, objectGroup } by (contact.OBJECTCONTACTPROJECT.Any() ? contact.OBJECTCONTACTPROJECT.FirstOrDefault().OBJECTPROJECT.PROJECTNAME : "General") into pGroup
                    orderby pGroup.Key == "General" ? pGroup.Key : "" descending 
                    select new ProjectViewModel()
                    {
                        ProjectName = pGroup.Key,
                        ProjectId = pGroup.FirstOrDefault() != null ? (pGroup.FirstOrDefault().contact.OBJECTCONTACTPROJECT.FirstOrDefault() != null ? pGroup.FirstOrDefault().contact.OBJECTCONTACTPROJECT.FirstOrDefault().OBJECTPROJECTID : -1) : -1,
                        ContactGroups = (from c in pGroup
                                group c by c.objectGroup into grp
                                let canEdit = ContactsModule.CheckUserRole("EDIT", grp.Key.OBJECTTYPE, grp.Key.GROUPNAME)
                                orderby grp.Key.SORTORDER descending 
                                select new ContactGroupViewModel()
                                {
                                    GroupName = grp.Key.GROUPNAME,
                                    GroupId = grp.Key.OBJECTGROUPID,
                                    CanEdit = canEdit,
                                    Contacts = grp.Select(item => new ContactViewModel()
                                    {
                                        Id = (int)item.contact.OBJECTCONTACTID,
                                        Name = item.contact.NAME,
                                        Description = item.contact.DESCRIPTION,
                                        Editable = canEdit,
                                        ContactInformation = item.contact.OBJECTCONTACTNUMBER.OrderByDescending(num => num.ISMAININFO).Select(num => new ContactInfoViewmodel()
                                        {
                                            Data = num.NUMBERDATA,
                                            IsMain = num.ISMAININFO > 0,
                                            Type = num.OBJECTCONTACTNUMBERTYPE.NAME
                                        }).ToList()
                                    }).ToList()
                                }).ToList()
                    }).ToList();
