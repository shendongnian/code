    var methodResult = Persons
                    .Include(x => x.Friend)
                    .Include(x => x.Group)
                    .SelectMany(person =>
                        person.Friend.SelectMany(friend =>
                            person.Group.Select(group =>
                                new {
                                    person.Id,
                                    person.SocialClass,
                                    person.CreatedDate,
                                    friend.FriendPersonId,
                                    friend.FriendType,
                                    GroupId = group.Id,
                                    group.MembershipLevel
                                }
                            )
                        )
                    );
