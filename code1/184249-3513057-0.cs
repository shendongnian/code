    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <session-factory>
          <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
          <property name="dialect">NHibernate.Dialect.Oracle10gDialect</property>
          <property name="default_schema">DUMMY</property>
          <property name="connection.driver_class">NHibernate.Driver.OracleClientDriver</property>
          <property name="connection.connection_string">Data Source=SRV_OLDEV;User Id=USRdummy;Password=USRdummy;</property>
        
          <property name="proxyfactory.factory_class">
            NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu
          </property>
          <property name="show_sql">true</property>
        </session-factory>
      </hibernate-configuration>
