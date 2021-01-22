    public class Table
    {
       public Table(IMapInfo map)
       {
          _map = map;
       }
       public string Name
       {
          get 
          {
            string value = _map.Eval("myexpression");
            if (String.IsNullOrEmpty(value))
            {
                value = "none";
            }
            return value;
          }
       }
       private IMapInfo _map;
    }
    [TestFixture]
    public class TableFixture // is this a pun?
    {
       [Test]
       public void CanHandleNullsFromCOM()
       {
           MockRepository mocks = new MockRepository(); // rhino mocks, btw
           IMapInfo map = mocks.CreateMock<IMapInfo>();
           using (mocks.Record())
           {
              Expect.Call(map.Eval("myexpression").Return(null);
           }
           using (mocks.PlayBack())
           {
              Table table = new Table(map);
              Assert.AreEqual("none", table.Name, "We didn't handle nulls correctly.");
           }
           mocks.verify();
       }
    }
