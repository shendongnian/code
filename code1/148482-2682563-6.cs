    <?xml version="1.0" encoding="utf-8" ?>    
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="dialect">NHibernate.Dialect.MsSql2000Dialect</property>
        <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
        <property name="connection.connection_string">Data Source=.\SQLEXPRESS;Initial Catalog=NHibernateDB; user=sa;Password=;Integrated Security=True</property>
        <property name="show_sql">false</property>
        <!--<property name="query.substitutions">true 1, false 0, yes 'Y', no 'N'</property>-->
        <mapping assembly="NHibernate_Test.BO" />
      </session-factory>
    </hibernate-configuration>
