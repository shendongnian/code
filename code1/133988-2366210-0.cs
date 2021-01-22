    public class Person
    {
       public Person(int id)
       {
          m_id = id;
       }
       readonly int m_id;
       public int Id { get { return m_id; } }
    }
