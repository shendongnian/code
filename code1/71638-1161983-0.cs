    public class StringValue
    {
        public String Name { get; set; }
    }
    <resultMap id="StringList" class="StringValue" >
      <result property="Name" column="Value"/>
    </resultMap>
