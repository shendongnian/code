    namespace StackOverflow
    {
        //broken BeanPouch class that uses the DebuggerDisplay attribute
        [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
        class BrokenBeanPouch : List<MagicBean>
        { }
    
        //working BeanPouch class that overrides ToString
        class WorkingBeanPouch : List<MagicBean>
        {
            public override string ToString()
            {
                return string.Format("Count = {0}", this.Count);
            }
        }
    
        class Program
        {
            static WorkingBeanPouch myWorkingBeans = new WorkingBeanPouch()
            {
                new MagicBean() { Value = 4.99m }, new MagicBean() { Value = 5.99m }, new MagicBean() { Value = 3.99m }
            };
    
            static BrokenBeanPouch myBrokenBeans = new BrokenBeanPouch()
            {
                new MagicBean() { Value = 4.99m }, new MagicBean() { Value = 5.99m }, new MagicBean() { Value = 3.99m }
            };
    
            static void Main(string[] args)
            {
                //break here so we can watch the beans in the watch window
                System.Diagnostics.Debugger.Break();
            }
        }
    
        class MagicBean
        {
            public decimal Value { get; set; }
        }    
    }
