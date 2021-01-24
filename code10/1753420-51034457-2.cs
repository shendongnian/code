            db.Clients.Add(new Client()
            {
                name = nameTB.Text,
                age = Convert.ToInt32(ageTB.Text)
            });
