        public async Task<bool> UpdatePersonAsync(Person person)
        {
            int numUpdated = 0;
            using (var db = new AndyPeopleContext())
            {
                db.People.Add(person);
                db.Entry(person).State = EntityState.Modified;
                numUpdated = await db.SaveChangesAsync();
            }
            return numUpdated == 1;
        }
