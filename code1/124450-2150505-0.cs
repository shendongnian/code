    MyObject mo = (MyObject)_session.CreateCriteria(typeof(MyObject))
                    .Add(Restrictions.Eq("Property", value))
                    .AddOrder(Order.Desc("Id"))
                    .SetMaxResults(1).UniqueResult();
                Log.Info(this, string.Format("Retrieving latest MyObject {0}.", mo.Name));
                return mo;
