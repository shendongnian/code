    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="dialect">NHibernate.Dialect.MsSql2005Dialect</property>
        <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
        <property name="connection.connection_string">Server=dev\sql2005;Initial Catalog=TestDB;Integrated Security=True</property>
        <property name="show_sql">true</property>
      </session-factory>
    </hibernate-configuration> 
