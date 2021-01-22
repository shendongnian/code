        public bool UnregisterFromEvent(Person person, Event entry)
        {
            var registrationEntry = this.session
                .CreateCriteria<PersonEventRegistration>()
                .Add(Restrictions.Eq("Person", person))
                .Add(Restrictions.Eq("Event", entry))
                .Add(Restrictions.Eq("IsComplete", false))
                .UniqueResult<PersonEventRegistration>();
            bool result = false;
            if (null != registrationEntry)
            {
                using (ITransaction tx = this.session.BeginTransaction())
                {
                    registrationEntry.Person = null;
                    registrationEntry.Event = null;
                    this.session.Delete(registrationEntry);
                    tx.Commit();
                    result = true;
                }
            }
            return result;
        }
