    var customers = query.ToList(r => new
                {
                    Id = r.Get<int>("Id"),
                    Name = r.Get<string>("Name"),
                    Age = r.Get<int>("Age"),
                    BirthDate = r.Get<DateTime?>("BirthDate"),
                    Bio = r.Get<string>("Bio"),
                    AccountBalance = r.Get<decimal?>("AccountBalance"),
                });
