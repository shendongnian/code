    public static Boolean CanWrite<T>(AccessControl.User user, T entity) where T : PersistanceLayerBaseClass
            {
                int? clubId = null;
                MethodInfo methodInfo = entity.GetType().GetMethod("CanWrite", new Type[] { typeof(AccessControl.User), entity.GetType() });
                if(methodInfo != null)
                {
                    return (Boolean)methodInfo.Invoke(null, new object[] { user, entity }) ;
                }
                else 
                {
                    //generic answer
                }
                return HasRole(user.UserID, "Administrator") || (clubId.HasValue && user.MemberObject.ClubId == clubId.Value && HasRole(user.UserID, "AdministerClub"));
            }
