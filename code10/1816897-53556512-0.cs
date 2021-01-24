    public class TestBase
    {
        [CompilerGenerated]
        private readonly string <ReadOnly>k__BackingField; // note: not legal in "real" C#
    
        public virtual string ReadOnly
        {
            [CompilerGenerated]
            get
            {
                return <ReadOnly>k__BackingField; // the one in TestBase
            }
        }
    
        public TestBase()
        {
            <ReadOnly>k__BackingField = "from base";
        }
    }
    internal class Test : TestBase
    {
        [CompilerGenerated]
        private readonly string <ReadOnly>k__BackingField;
    
        public override string ReadOnly
        {
            [CompilerGenerated]
            get
            {
                return <ReadOnly>k__BackingField; // the one in Test
            }
        }
    }
