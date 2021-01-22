    public class MyClass
    {
       Transactional<int> m_Number = new Transactional<int>(3);
    public void MyMethod()
       {
          Transactional<string> city = new Transactional<string>("New York");
    
          using(TransactionScope scope = new TransactionScope())
          {
             city.Value = "London";
             m_Number.Value = 4;
             m_Number.Value++;
             Debug.Assert(m_Number.Value == 5);
    
             //No call to scope.Complete(), transaction will abort
          }
    }
