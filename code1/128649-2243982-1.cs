    <class name="Template">
        <component name="SpecialInstructions">
            <property name="Line1" column="spx_1"/>
            <property name="Line2" column="spx_2"/>
            <property name="Line3" column="spx_3"/>
            <property name="Line4" column="spx_4"/>
        </component>
    <class>
    public class Template
    {
        public Instructions SpecialInstructions { get; set; }
    }
    public class Instructions
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
    }
