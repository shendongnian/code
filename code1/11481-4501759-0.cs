      <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <reflection-optimizer use="true" />
        <session-factory>
          <property name="connection.connection_string_name">testSqlLiteDB</property>
          <property name="connection.driver_class">NHibernate.Driver.SQLite20Driver</property>
          <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
          <property name="connection.release_mode">on_close</property>
          <property name="dialect">NHibernate.Dialect.SQLiteDialect</property>
          <property name="proxyfactory.factory_class">NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle</property>
          <property name="query.substitutions">true=1;false=0</property>
        </session-factory>
      </hibernate-configuration>
