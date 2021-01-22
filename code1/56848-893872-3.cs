            public static void DefaultSetup()
        {
           // AllToConsoleSetup();
            XmlConfigurator.Configure(XmlSetup());
          // DbConfig();
        }
        private static Stream XmlSetup()
        {
            const string x = @" <log4net>
    <root>
      <level value=""ALL"" />
      <appender-ref ref=""AdoNetAppender"">
       
      </appender-ref>
    </root>
    <appender name=""AdoNetAppender"" type=""log4net.Appender.AdoNetAppender"">
      <bufferSize value=""1"" />
      <connectionType value=""System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" />
      <connectionString value=""data source=Christian-PC\SQLEXPRESS;initial catalog=log4net_2;integrated security=false;persist security info=True;User ID=log4net;Password=XXXX"" />
      <commandText value=""INSERT INTO Log ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level, @logger, @message, @exception)"" />
      <parameter>
        <parameterName value=""@log_date"" />
        <dbType value=""DateTime"" />
        <layout type=""log4net.Layout.RawTimeStampLayout"" />
      </parameter>
      <parameter>
        <parameterName value=""@thread"" />
        <dbType value=""String"" />
        <size value=""655"" />
        <layout type=""log4net.Layout.PatternLayout"">
          <conversionPattern value=""%thread"" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value=""@log_level"" />
        <dbType value=""String"" />
        <size value=""50"" />
        <layout type=""log4net.Layout.PatternLayout"">
          <conversionPattern value=""%level"" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value=""@logger"" />
        <dbType value=""String"" />
        <size value=""655"" />
        <layout type=""log4net.Layout.PatternLayout"">
          <conversionPattern value=""%logger"" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value=""@message"" />
        <dbType value=""String"" />
        <size value=""4000"" />
        <layout type=""log4net.Layout.PatternLayout"">
          <conversionPattern value=""%message"" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value=""@exception"" />
        <dbType value=""String"" />
        <size value=""2000"" />
        <layout type=""log4net.Layout.ExceptionLayout"" />
      </parameter>
      <filter type=""log4net.Filter.LoggerMatchFilter"">
        <param name=""LoggerToMatch"" value=""Ruppert"" />
      </filter>
      <filter type=""log4net.Filter.DenyAllFilter"">
      </filter>
    </appender>
