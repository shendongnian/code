    /// <summary>
    /// Testing the mapping of our entities.
    /// there must be a server connection for this kind of test.
    /// </summary>
    [TestFixture]
    internal class someMappingTest
    {
        [Test(Description = "Check the Encoding Profile FluentNHibernate Mapping")]
        [Timeout(20000)]
        public void checkthatMappingWorks()
        {
            // creatw the new entity
            TestedType testOn = new TestedType();
            // set the initialization values
            testOn.Name = "TestProfileExecution";
            
            // create the test object
            new GenericMappingTesterWithRealDB<TestedType>
            {
                // assign an entity
                EntityToTest = testOn,
                // assign new values for update check
                PerformEntityManipulationBeforeUpdate =
                    delegate(TestedType testedTypeBeingTested)
                        {
                            return testedTypeBeingTested.Name = "Updateing Test";
                        }
            }.
            // call run test to perform the mapping test.
            RunTest();
        }
    }
