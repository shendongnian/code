    [TestMethod()]
            public void IngredientDAONHibernateConstructorTest()
            {
                _errorLogged = false;
                ILogger logger = this; // make test fixture implement the logger interface ; self-shunt
                IngredientDAONHibernate target = new IngredientDAONHibernate(logger);
    
                Assert.IsNotNull(target);
                Assert.IsFalse(_errorLogged, 
                   String.Format("ERROR! Constructor has thrown {0}", _loggedException) );
            }
            
            bool _errorLogged;
            Exception _loggedException;
            public void Error(string message, Exception e)
            { 
               _errorLogged = true;
               _loggedException = e;
            } 
