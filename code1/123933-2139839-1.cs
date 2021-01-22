        [TestMethod]
        public void SutHasDataContractAttribute()
        {
            // Fixture setup
            // Exercise system and verify outcome
            new Fixture().SutHasAttribute<Flag>(typeof(DataContractAttribute));
            // Teardown
        }
        [TestMethod]
        public void FlagGroupIdHasDataMemberAttribute()
        {
            // Fixture setup
            // Exercise system and verify outcome
            new Fixture().SutPropertyHasAttribute((Flag f) => f.FlagGroupId, typeof(DataMemberAttribute));
            // Teardown
        }
