    public class ModelObject
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        // more properties here
    }
    
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" namespace="Model" assembly="API">
        <class name="ModelObject" table="dbname.dbo.tablename" lazy="false">
            <id name="ID" column="tablename_id" type="int">
	        <generator class="native" />
	    </id>
            <property name="CountryID" column="tablename_country_id" type="int" />
            <!-- more properties here -->
        </class>
    </hibernate-mapping>
