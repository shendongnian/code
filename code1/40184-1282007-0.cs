     internal class GenericMappingTesterWithRealDB<T> where T : IIdentifiable
    {
        public T EntityToTest { get; set; }
        public Func<T, object> PerformEntityManipulationBeforeUpdate { get; set; }
        public GenericMappingTesterWithRealDB()
        {
            Assume.That(SessionFactoryProvider.NewSession,Is.Not.Null);
        }
        public void RunTest()
        {
            using (ISession session = SessionFactoryProvider.NewSession)
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(EntityToTest);
                    var item = session.Get<T>(EntityToTest.ID);
                    Assert.IsNotNull(item);
                    if (PerformEntityManipulationBeforeUpdate != null)
                    {
                        PerformEntityManipulationBeforeUpdate.Invoke(EntityToTest);
                    }
                    session.Update(EntityToTest);
                    session.Delete(EntityToTest);
                    session.Save(EntityToTest);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message, e.StackTrace);
                }
                finally
                {
                    transaction.Rollback();
                }
            }
        }
    }
