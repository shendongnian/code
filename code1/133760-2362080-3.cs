    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime SignupDate { get; set; }
    }
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Count { get; set; }
    }
    <class name="User" table="user">
      <id name="Id">
        <generator class="native" />
      </id>
      <property name="Name" />
      <property name="SignupDate" />
    </class>
    <class name="Post" table="post">
      <id name="Id">
        <generator class="native" />
      </id>
      <property name="Title" />
      <property name="Body" type="StringCLob" /> <!-- ntext -->
      <many-to-one name="User" />
      <bag name="Tags" table="post_tag" cascade="save-update">
          <key column="postid" />
          <many-to-many class="Tag" column="tagid" />
      </bag>
    </class>
    <class name="Tag" table="tag">
      <id name="Id">
        <generator class="native" />
      </id>
      <property name="Name" />
      <property name="Count" />
    </class>
