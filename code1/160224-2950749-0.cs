    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
        <section name="exceptionHandling" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.ExceptionHandlingSettings, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
        <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
        <section name="validationConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Validation.Configuration.ValidationSettings, Microsoft.Practices.EnterpriseLibrary.Validation, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
      </configSections>
    
      <loggingConfiguration configSource="logging.config"/>
      <exceptionHandlingConfiguration configSource="exceptionHandling.config"/>
      <dataConfiguration configSource="dataAccess.config"/>
      <validationConfiguration configSource="validation.config"/>
    </configuration>
