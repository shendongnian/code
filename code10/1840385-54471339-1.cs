    using System.Collections.Generic;
    using Xunit;
    
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IEntity ientity = new TargetImpl();
            ientity.Save(new List<Job>());
        }
    }
