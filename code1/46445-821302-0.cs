        using System;
        using System.Collections.Generic;
        using System.Text;
        using log4net;
        using log4net.Config;
        
        
        namespace ExampleConsoleApplication
        {
          enum DebugLevel : int
          { 
            Fatal_Msgs = 0 , 
            Fatal_Error_Msgs = 1 , 
            Fatal_Error_Warn_Msgs = 2 , 
            Fatal_Error_Warn_Info_Msgs = 3 ,
            Fatal_Error_Warn_Info_Debug_Msgs = 4 
          }
        	
        
        	class TestClass
        	{
        
        		private static readonly ILog logger =
        				 LogManager.GetLogger ( typeof ( TestClass ) );
        
        
        		static void Main ( string[] args )
        		{
              TestClass objTestClass = new TestClass ();
        //log4net.Appender.ColoredConsoleAppender.Colors.HighIntensity
        			Console.WriteLine ( " START " );
        
              int shouldLog = 4; //CHANGE THIS FROM 0 TO 4 integer to check the functionality of the example
              //0 -- prints only FATAL messages 
              //1 -- prints FATAL and ERROR messages 
              //2 -- prints FATAL , ERROR and WARN messages 
              //3 -- prints FATAL  , ERROR , WARN and INFO messages 
              //4 -- prints FATAL  , ERROR , WARN , INFO and DEBUG messages 
        
              string srtLogLevel = String.Empty ; 
              switch (shouldLog)
              {
                case (int)DebugLevel.Fatal_Msgs :
                  srtLogLevel = "FATAL";
                  break;
                case (int)DebugLevel.Fatal_Error_Msgs:
                  srtLogLevel = "ERROR";
                  break;
                case (int)DebugLevel.Fatal_Error_Warn_Msgs :
                  srtLogLevel = "WARN";
                  break;
                case (int)DebugLevel.Fatal_Error_Warn_Info_Msgs :
                  srtLogLevel = "INFO"; 
                  break;
                case (int)DebugLevel.Fatal_Error_Warn_Info_Debug_Msgs :
                  srtLogLevel = "DEBUG" ;
                  break ;
                default:
                  srtLogLevel = "FATAL";
                  break;
              }
        
                objTestClass.SetLogingLevel ( srtLogLevel );
         
        
              objTestClass.LogSomething ();
        
        
        			Console.WriteLine ( " END HIT A KEY TO EXIT " );
        			Console.ReadLine ();
        			} //eof method 
        
            /// <summary>
            /// Activates debug level 
            /// </summary>
            /// <sourceurl>http://geekswithblogs.net/rakker/archive/2007/08/22/114900.aspx</sourceurl>
            private void SetLogingLevel ( string strLogLevel )
            {
             string strChecker = "WARN_INFO_DEBUG_ERROR_FATAL" ;
        
              if (String.IsNullOrEmpty ( strLogLevel ) == true || strChecker.Contains ( strLogLevel ) == false)
                throw new Exception ( " The strLogLevel should be set to WARN , INFO , DEBUG ," );
        
              
        
              log4net.Repository.ILoggerRepository[] repositories = log4net.LogManager.GetAllRepositories ();
        
              //Configure all loggers to be at the debug level.
              foreach (log4net.Repository.ILoggerRepository repository in repositories)
              {
                repository.Threshold = repository.LevelMap[ strLogLevel ];
                log4net.Repository.Hierarchy.Hierarchy hier = (log4net.Repository.Hierarchy.Hierarchy)repository;
                log4net.Core.ILogger[] loggers = hier.GetCurrentLoggers ();
                foreach (log4net.Core.ILogger logger in loggers)
                {
                  ( (log4net.Repository.Hierarchy.Logger)logger ).Level = hier.LevelMap[ strLogLevel ];
                }
              }
        
              //Configure the root logger.
              log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository ();
              log4net.Repository.Hierarchy.Logger rootLogger = h.Root;
              rootLogger.Level = h.LevelMap[ strLogLevel ];
            }
        
            private void LogSomething ()
            {
              #region LoggerUsage
              DOMConfigurator.Configure (); //tis configures the logger 
              logger.Debug ( "Here is a debug log." );
              logger.Info ( "... and an Info log." );
              logger.Warn ( "... and a warning." );
              logger.Error ( "... and an error." );
              logger.Fatal ( "... and a fatal error." );
              #endregion LoggerUsage
        
            }
        	} //eof class 
        
        } //eof namespace 
        
        
        
        
        
        
        #region TheAppConfig
        /*
         <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
        	<configSections>
        		<section name="log4net"
        				 type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
        	</configSections>
        	<log4net>
        		<appender name="LogFileAppender" type="log4net.Appender.FileAppender">
        			<param name="File" value="LogTest2.txt" />
        			<param name="AppendToFile" value="true" />
        			<layout type="log4net.Layout.PatternLayout">
        				<param name="Header" value="[Header] \r\n" />
        				<param name="Footer" value="[Footer] \r\n" />
        				<param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
        			</layout>
        		</appender>
        
        		<appender name="ColoredConsoleAppender" type="log4net.Appender.ColoredConsoleAppender">
        			<mapping>
        				<level value="ERROR" />
        				<foreColor value="White" />
        				<backColor value="Red, HighIntensity" />
        			</mapping>
        			<layout type="log4net.Layout.PatternLayout">
        				<conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
        			</layout>
        		</appender>
        
        
        		<appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
        			<connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=1.2.10.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
        			<connectionString value="data source=ysg;initial catalog=DBGA_DEV;integrated security=true;persist security info=True;" />
        			<commandText value="INSERT INTO [DBGA_DEV].[ga].[tb_Data_Log] ([Date],[Thread],[Level],[Logger],[Message]) VALUES (@log_date, @thread, @log_level, @logger, @message)" />
        			
        			<parameter>
        				<parameterName value="@log_date" />
        				<dbType value="DateTime" />
        				<layout type="log4net.Layout.PatternLayout" value="%date{yyyy'-'MM'-'dd HH':'mm':'ss'.'fff}" />
        			</parameter>
        			<parameter>
        				<parameterName value="@thread" />
        				<dbType value="String" />
        				<size value="255" />
        				<layout type="log4net.Layout.PatternLayout" value="%thread" />
        			</parameter>
        			<parameter>
        				<parameterName value="@log_level" />
        				<dbType value="String" />
        				<size value="50" />
        				<layout type="log4net.Layout.PatternLayout" value="%level" />
        			</parameter>
        			<parameter>
        				<parameterName value="@logger" />
        				<dbType value="String" />
        				<size value="255" />
        				<layout type="log4net.Layout.PatternLayout" value="%logger" />
        			</parameter>
        			<parameter>
        				<parameterName value="@message" />
        				<dbType value="String" />
        				<size value="4000" />
        				<layout type="log4net.Layout.PatternLayout" value="%messag2e" />
        			</parameter>
        		</appender>
        		<root>
        			<level value="INFO" />
        			<appender-ref ref="LogFileAppender" />
        			<appender-ref ref="AdoNetAppender" />
        			<appender-ref ref="ColoredConsoleAppender" />
        		</root>
        	</log4net>
        </configuration>
         */
        #endregion TheAppconfig
        #region TheReferencesInThecsprojFile
        //<Reference Include="log4net, Version=1.2.10.0, Culture=neutral, PublicKeyToken=1b44e1d426115821, processorArchitecture=MSIL">
        //  <SpecificVersion>False</SpecificVersion>
        //  <HintPath>..\..\..\Log4Net\log4net-1.2.10\bin\net\2.0\release\log4net.dll</HintPath>
        //</Reference>
        //<Reference Include="nunit.framework, Version=2.4.8.0, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL" />
        #endregion TheReferencesInThecsprojFile
 
