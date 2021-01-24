                            if(contactIDList.Count>0)
                            {
                                newContactPosition.PositionID = value;
                                for (int add = 0; add < contactIDList.Count; add++)
                                {
                                    newContactPosition.ContactID = contactIDList[add];
                                    ContactPositionDB.AddContactPosition(newContactPosition);
                                }
                            }
