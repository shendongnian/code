    public class User
    {
        public virtual int Id
        { get; set; }
        public virtual string Name
        { get; set; }
        public virtual DateTime SignupDate
        { get; set; }
    }
    <class name="User" table="user">
      <id name="Id">
        <generator class="native" />
      </id>
      <property name="Name" />
      <property name="SignupDate" />
    </class>
     
