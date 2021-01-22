        if (ModelState.IsValid)
        {
            var person= GetPerson(id);
            person.Name= model.Name;
            person.Age = model.Age;
            var rolesToAdd = model.Roles.Where(mr => !person.Roles.Any(pr => pr.Id == mr);
            var rolesToRemove = person.Roles.Where(pr => !model.Roles.Any(mr => pr.Id == mr);
            foreach (string rId in rolesToAdd)
            {
                person.Roles.Add(this.RoleRepository.Single(r => r.Id.ToString() == rId));
            }
            foreach (string rrId in rolesToRemove)
            {
                var remove = person.Roles.Where(r => r.Id == rrId).Single();
                person.Roles.Remove(remove);
            }
            this.PersonRepository.SaveChanges();
            return RedirectToIndex(personId);
        }
