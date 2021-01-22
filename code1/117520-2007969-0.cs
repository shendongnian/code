            using( var session = sessionFactory.OpenSession() )
            {
                session.BeginTransaction();
                var foos =
                    session.CreateCriteria(typeof(Foo))
                           .List<Foo>();
                var miniFoos = 
                   foos.Select(f => new { f.email, f.bars })
                       .Where(f => f.email.Equals("foo@bar.com)
                       .ToList();
                session.Close();
             }
