    UserCriteria userCriteria = (UserCriteria)criteria;
                    if (userCriteria.UserId != 0)
                    {
                        UserDAO userDAO = UserDAO.TryFind(userCriteria.UserId);
                    }
                    else if (userCriteria.MasterDataId != 0)
                    {
                        UserDAO userDAO = UserDAO.FindOne(Restrictions.Eq(UserDAO.GetPropertyColumnName("ExternalId1"), userCriteria.MasterDataId));
                    }
                    else if (!userCriteria.ADName.Equals(string.Empty))
                    {
                        UserDAO userDAO = UserDAO.FindOne(Restrictions.Eq(UserDAO.GetPropertyColumnName("ADName"), userCriteria.ADName.ToLower()));
                    }
