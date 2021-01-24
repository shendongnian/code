            var newB = new B();
            newB.Name = b.Name;
            newB.Id = b.Id;
            realm.Add(newB, update: true);
            foreach (var element in b.AList)
            {
                newB.Devices.Add(element);
            }
            trans.Commit();
