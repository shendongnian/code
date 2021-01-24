C#
       [Theory]
       [ClassData(typeof(RunTestWithMemberDataCollection))]
       public async Task RunTestWithMemberData(RunTestWithMemberDataCollection.TestItem data)
       {
       }
    
       public class RunTestWithMemberDataCollection :
           ClassDataCollection<RunTestWithMemberDataCollection.TestItem>
       {
           public override IEnumerable<TestItem> GetData()
           {
               yield return new TestItem { Prop1 = "", Prop2 = "data 1" };
               yield return new TestItem { Prop1 = "", Prop2 = "data 2" };
           }
    
           public class TestItem : ClassDataItem
           {
               public string Prop1 { get; set; }
    
               public string Prop2 { get; set; }
           }
       }
And here is the supporting code that you only need once:
C#
    public abstract class ClassDataCollection<T> : IEnumerable<object[]>
        where T : ClassDataItem
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return GetData()
                .Select(d => new object[] { (IXunitSerializable)d })
                .GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public abstract IEnumerable<T> GetData();
    }
    public class ClassDataItem : IXunitSerializable
    {
        public void Deserialize(IXunitSerializationInfo info)
        {
            JsonConvert.PopulateObject(info.GetValue<string>("TestItem"), this);
        }
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("TestItem", JsonConvert.SerializeObject(this));
        }
    }
