    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    
      <configSections>
        <section name="hibernate-configuration" type="NHibernate.Cfg.ConfigurationSectionHandler, NHibernate" />
      </configSections>
    
      <!-- NHibernate Configuration -->
      <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <session-factory>
          <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
          <property name="dialect">NHibernate.Dialect.MsSql2005Dialect</property>
          <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
          <property name="connection.connection_string">Data Source=(local)\sqlexpress;Initial Catalog= NHibernateDB;user=sa;Password=;Integrated Security=True;</property>
    <mapping assembly="NHibernate_Test.BO"/>
        </session-factory>
      </hibernate-configuration>
    </configuration>
