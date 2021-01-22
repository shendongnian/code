      using System;
      using System.Collections.Generic;
      using System.Text;
      using log4net;
      using log4net.Config;
      using NUnit.Framework;
      using GenApp.Utils; 
      
      namespace ExampleConsoleApplication
      {
      	
      
      	class TestClass
      	{
      
      		private static readonly ILog logger =
      				 LogManager.GetLogger ( typeof ( TestClass ) );
      
      
      		static void Main ( string[] args )
      		{
            TestClass objTestClass = new TestClass ();
      //log4net.Appender.ColoredConsoleAppender.Colors.HighIntensity
            GenApp.Bo.UserSettings us = new GenApp.Bo.UserSettings ();
            GenApp.Bo.User userObj = new GenApp.Bo.User ()
            {
    
              UserSettings = us
    
            };
            userObj.UserSettings.LogLevel = 4; 
    
    
            
    
            #region SetDynamicallyLogLevel
            
    
            Logger.Debug ( userObj, logger, " -- Debug msg -- " );
            Logger.Info ( userObj, logger, " -- Info msg -- " );
            Logger.Warn ( userObj, logger, " -- Warn msg -- " );
            Logger.Error ( userObj, logger, " -- Error msg -- " );
            Logger.Fatal ( userObj, logger, " -- Fatal msg -- " );
            #endregion SetDynamicallyLogLevel
    
    
    
            #region RemoveDynamicallyAppenders
            Logger.SetThreshold ( "LogFileAppender", log4net.Core.Level.Off );
    
            //and echo again
            Logger.Debug ( userObj, logger, " -- Debug msg -- " );
            Logger.Info ( userObj, logger, " -- Info msg -- " );
            Logger.Warn ( userObj, logger, " -- Warn msg -- " );
            Logger.Error ( userObj, logger, " -- Error msg -- " );
            Logger.Fatal ( userObj, logger, " -- Fatal msg -- " );
    
    
    
            #endregion RemoveDynamicallyAppenders
    
            Console.WriteLine ( " END HIT A KEY TO EXIT " );
      			Console.ReadLine ();
      			} //eof method 
    
          
      	} //eof class 
      
      } //eof namespace 
    
    
    
    
      /* App.config CopyPaste 
      <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    <configSections>
      <section name="log4net"
           type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
    </configSections>
    
    <log4net>
      <appender name="LogFileAppender" type="log4net.Appender.FileAppender">
        <param name="File" value="Program.log" />
        <param name="AppendToFile" value="true" />
        <layout type="log4net.Layout.PatternLayout">
          <!--<param name="Header" value="======================================" />
          <param name="Footer" value="======================================" />-->
          <param name="ConversionPattern" value="%date{yyyy'.'MM'.'dd --- HH':'mm':'ss'.'fff} [%t] %-5p -- %m%n" />
        </layout>
      </appender>
    
      <appender name="ColoredConsoleAppender" type="log4net.Appender.ColoredConsoleAppender">
        <mapping>
          <level value="ERROR" />
          <foreColor value="Red" />
        </mapping>
        <mapping>
          <level value="DEBUG" />
          <foreColor value="HighIntensity" />
        </mapping>
        <mapping>
          <level value="INFO" />
          <foreColor value="Green" />
        </mapping>
        <mapping>
          <level value="WARN" />
          <foreColor value="Yellow" />
        </mapping>
        <mapping>
          <level value="FATAL" />
          <foreColor value="White" />
          <backColor value="Red" />
        </mapping>
    
        <layout type="log4net.Layout.PatternLayout">
          <!-- You could change here the date format -->
          <conversionPattern value="%date{yyyy'.'MM'.'dd --- HH':'mm':'ss'.'fff}  [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
        </layout>
      </appender>
    
    
      <appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
        <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=1.2.10.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
        <connectionString value="data source=ysg;initial catalog=DBGA_DEV;integrated security=true;persist security info=True;" />
        <commandText value="INSERT INTO [DBGA_DEV].[ga].[tb_Data_Log] ([Date],[Thread],[Level],[Logger],[Message]) VALUES (@log_date, @thread, @log_level, @logger, @message)" />
    		
        <parameter>
          <parameterName value="@log_date" />
          <dbType value="DateTime" />
          <layout type="log4net.Layout.PatternLayout" value="%date{yyyy'.'MM'.'dd HH':'mm':'ss'.'fff}" />
        </parameter>
        <parameter>
          <parameterName value="@thread" />
          <dbType value="String" />
          <size value="255" />
          <layout type="log4net.Layout.PatternLayout" value="%thread" />
        </parameter>
        <parameter>
          <parameterName value="@domainName" />
          <dbType value="String" />
          <size value="255" />
          <layout type="log4net.Layout.PatternLayout" value="%user" />
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
          <layout type="log4net.Layout.PatternLayout" value="%message" />
        </parameter>
      </appender>
      <root>
        <level value="ALL" />
        <appender-ref ref="LogFileAppender" />
        <appender-ref ref="AdoNetAppender" />
        <appender-ref ref="ColoredConsoleAppender" />
      </root>
    </log4net>
    </configuration>
       */
      #region TheReferencesInThecsprojFile
      //<Reference Include="log4net, Version=1.2.10.0, Culture=neutral, PublicKeyToken=1b44e1d426115821, processorArchitecture=MSIL">
      //  <SpecificVersion>False</SpecificVersion>
      //  <HintPath>..\..\..\Log4Net\log4net-1.2.10\bin\net\2.0\release\log4net.dll</HintPath>
      //</Reference>
      //<Reference Include="nunit.framework, Version=2.4.8.0, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL" />
      #endregion TheReferencesInThecsprojFile
 
    namespace GenApp.Bo
    {
      public class User
      {
        
        public int LogLevel { get; set; }
        public UserSettings UserSettings { get; set; }
    
    
      } //eof class 
      
      public class UserSettings
      {
        public int LogLevel;
      }
    
    } //eof namespace 
    namespace GenApp.Utils
    {
      ///<version> 1.1 </version>
      ///<author> Yordan Georgiev </author>
      ///<summary> Wrapper around log4net with dynamically adjustable verbosity</summary>
      public class Logger
      {
    
        private static Logger inst = new Logger ();
        public static Logger Inst ()
        {
          inst.ConfigureLogging ();
          return inst;
        }
    
    
        public enum DebugLevel : int
        {
          Fatal_Msgs = 0,
          Fatal_Error_Msgs = 1,
          Fatal_Error_Warn_Msgs = 2,
          Fatal_Error_Warn_Info_Msgs = 3,
          Fatal_Error_Warn_Info_Debug_Msgs = 4
        }
    
        public static void Debug ( GenApp.Bo.User userObj, ILog logger, string msg )
        {
          DebugLevel debugLevel = (DebugLevel)userObj.UserSettings.LogLevel;
          string strLogLevel = Logger.GetLogTypeString ( debugLevel );
          inst.SetLogingLevel ( strLogLevel );
          logger.Debug ( msg );
    
        } //eof method 
    
    
        public static void Info ( GenApp.Bo.User userObj, ILog logger, string msg )
        {
          DebugLevel debugLevel = (DebugLevel)userObj.UserSettings.LogLevel;
          string strLogLevel = Logger.GetLogTypeString ( debugLevel );
          inst.SetLogingLevel ( strLogLevel );
          logger.Info ( msg );
    
        } //eof method 
    
    
        public static void Warn ( GenApp.Bo.User userObj, ILog logger, string msg )
        {
          DebugLevel debugLevel = (DebugLevel)userObj.UserSettings.LogLevel;
          string strLogLevel = Logger.GetLogTypeString ( debugLevel );
          inst.SetLogingLevel ( strLogLevel );
          logger.Warn ( msg );
    
        } //eof method 
    
    
        public static void Error ( GenApp.Bo.User userObj, ILog logger, string msg )
        {
          DebugLevel debugLevel = (DebugLevel)userObj.UserSettings.LogLevel;
          string strLogLevel = Logger.GetLogTypeString ( debugLevel );
          inst.SetLogingLevel ( strLogLevel );
          logger.Error ( msg );
        } //eof method 
    
    
        public static void Fatal ( GenApp.Bo.User userObj, ILog logger, string msg )
        {
          DebugLevel debugLevel = (DebugLevel)userObj.UserSettings.LogLevel;
          string strLogLevel = Logger.GetLogTypeString ( debugLevel );
          inst.SetLogingLevel ( strLogLevel );
          logger.Fatal ( msg );
        } //eof method 
    
    
        /// <summary>
        /// Activates debug level 
        /// </summary>
        /// <sourceurl>http://geekswithblogs.net/rakker/archive/2007/08/22/114900.aspx</sourceurl>
        private void SetLogingLevel ( string strLogLevel )
        {
    
          this.ConfigureLogging ();
          string strChecker = "WARN_INFO_DEBUG_ERROR_FATAL";
    
          if (String.IsNullOrEmpty ( strLogLevel ) == true || strChecker.Contains ( strLogLevel ) == false)
            throw new ArgumentOutOfRangeException ( " The strLogLevel should be set to WARN , INFO , DEBUG ," );
    
    
    
          log4net.Repository.ILoggerRepository[] repositories = log4net.LogManager.GetAllRepositories ();
    
          //Configure all loggers to be at the debug level.
          foreach (log4net.Repository.ILoggerRepository repository in repositories)
          {
            repository.Threshold = repository.LevelMap[strLogLevel];
            log4net.Repository.Hierarchy.Hierarchy hier = (log4net.Repository.Hierarchy.Hierarchy)repository;
            log4net.Core.ILogger[] loggers = hier.GetCurrentLoggers ();
            foreach (log4net.Core.ILogger logger in loggers)
            {
              ( (log4net.Repository.Hierarchy.Logger)logger ).Level = hier.LevelMap[strLogLevel];
            }
          }
    
          //Configure the root logger.
          log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository ();
          log4net.Repository.Hierarchy.Logger rootLogger = h.Root;
          rootLogger.Level = h.LevelMap[strLogLevel];
        }
    
        ///<summary>
        ///0 -- prints only FATAL messages 
        ///1 -- prints FATAL and ERROR messages 
        ///2 -- prints FATAL , ERROR and WARN messages 
        ///3 -- prints FATAL  , ERROR , WARN and INFO messages 
        ///4 -- prints FATAL  , ERROR , WARN , INFO and DEBUG messages 
        ///</summary>
        private static string GetLogTypeString ( DebugLevel debugLevel )
        {
    
          string srtLogLevel = String.Empty;
          switch (debugLevel)
          {
            case DebugLevel.Fatal_Msgs:
              srtLogLevel = "FATAL";
              break;
            case DebugLevel.Fatal_Error_Msgs:
              srtLogLevel = "ERROR";
              break;
            case DebugLevel.Fatal_Error_Warn_Msgs:
              srtLogLevel = "WARN";
              break;
            case DebugLevel.Fatal_Error_Warn_Info_Msgs:
              srtLogLevel = "INFO";
              break;
            case DebugLevel.Fatal_Error_Warn_Info_Debug_Msgs:
              srtLogLevel = "DEBUG";
              break;
            default:
              srtLogLevel = "FATAL";
              break;
          } //eof switch
          return srtLogLevel;
    
        } //eof GetLogTypeString
    
    
        /// <summary>
        /// The path where the configuration is read from.
        /// This value is set upon a call to ConfigureLogging().
        /// </summary>
        private string configurationFilePath;
        public void ConfigureLogging ()
        {
          lock (this)
          {
            bool configured = false;
    
    
            #region ConfigureByThePathOfTheEntryAssembly
            // Tells the logging system the correct path.
            Assembly a = Assembly.GetEntryAssembly ();
    
            if (a != null && a.Location != null)
            {
              string path = a.Location + ".config";
    
              if (File.Exists ( path ))
              {
                log4net.Config.DOMConfigurator.Configure (
                  new FileInfo ( path ) );
                configurationFilePath = path;
                configured = true;
              }
              else
              {
                path = FindConfigInPath ( Path.GetDirectoryName ( a.Location ) );
                if (File.Exists ( path ))
                {
                  log4net.Config.DOMConfigurator.Configure (
                    new FileInfo ( path ) );
                  configurationFilePath = path;
                  configured = true;
                }
              }
            }
            #endregion ConfigureByThePathOfTheEntryAssembly
    
    
            #region ConfigureByWeb.config
            //// Also, try web.config.
            //if (!configured)
            //{
            //  if (HttpContext.Current != null &&
            //    HttpContext.Current.Server != null &&
            //    HttpContext.Current.Request != null)
            //  {
            //    string path = HttpContext.Current.Server.MapPath (
            //      HttpContext.Current.Request.ApplicationPath );
    
            //    path = path.TrimEnd ( '\\' ) + "\\Web.config";
    
            //    if (File.Exists ( path ))
            //    {
            //      log4net.Config.DOMConfigurator.Configure (
            //        new FileInfo ( path ) );
            //      configurationFilePath = path;
            //      configured = true;
            //    }
            //  }
            //}
            #endregion ConfigureByWeb.config
    
    
            #region ConfigureByThePathOfTheExecutingAssembly
            if (!configured)
            {
              // Tells the logging system the correct path.
              a = Assembly.GetExecutingAssembly ();
    
              if (a != null && a.Location != null)
              {
                string path = a.Location + ".config";
    
                if (File.Exists ( path ))
                {
                  log4net.Config.DOMConfigurator.Configure (
                    new FileInfo ( path ) );
                  configurationFilePath = path;
                  configured = true;
                }
                else
                {
                  path = FindConfigInPath ( Path.GetDirectoryName ( a.Location ) );
                  if (File.Exists ( path ))
                  {
                    log4net.Config.DOMConfigurator.Configure (
                      new FileInfo ( path ) );
                    configurationFilePath = path;
                    configured = true;
                  }
                }
              }
            }
            #endregion ConfigureByThePathOfTheExecutingAssembly
    
    
            #region ConfigureByThePathOfTheCallingAssembly
            if (!configured)
            {
              // Tells the logging system the correct path.
              a = Assembly.GetCallingAssembly ();
    
              if (a != null && a.Location != null)
              {
                string path = a.Location + ".config";
    
                if (File.Exists ( path ))
                {
                  log4net.Config.DOMConfigurator.Configure (
                    new FileInfo ( path ) );
                  configurationFilePath = path;
                  configured = true;
                }
                else
                {
                  path = FindConfigInPath ( Path.GetDirectoryName ( a.Location ) );
                  if (File.Exists ( path ))
                  {
                    log4net.Config.DOMConfigurator.Configure (
                      new FileInfo ( path ) );
                    configurationFilePath = path;
                    configured = true;
                  }
                }
              }
            }
            #endregion ConfigureByThePathOfTheCallingAssembly
    
    
            #region ConfigureByThePathOfTheLibIsStored
            if (!configured)
            {
              // Look in the path where this library is stored.
              a = Assembly.GetAssembly ( typeof ( Logger ) );
    
              if (a != null && a.Location != null)
              {
                string path = FindConfigInPath ( Path.GetDirectoryName ( a.Location ) );
                if (File.Exists ( path ))
                {
                  log4net.Config.DOMConfigurator.Configure (
                    new FileInfo ( path ) );
                  configurationFilePath = path;
                  configured = true;
                }
              }
            }
            #endregion ConfigureByThePathOfTheLibIsStored
    
    
    
          } //eof lock	 
        } //eof method 
    
    
    
        /// <summary>
        /// Searches for a configuration file in the given path.
        /// </summary>
        private string FindConfigInPath (
          string path )
        {
          string[] files = Directory.GetFiles ( path );
    
          if (files != null && files.Length > 0)
          {
            foreach (string file in files)
            {
              if (Path.GetExtension ( file ).Trim ( '.' ).ToLower (
                CultureInfo.CurrentCulture ) == "config")
              {
                return file;
              }
            }
          }
    
          // Not found.
          return string.Empty;
        } //eof method 
    
    
    
        /// <summary>
        /// Remove dynamically appenders
        /// </summary>
        /// <param name="appenderName"></param>
        /// <param name="threshold"></param>
        public static void SetThreshold ( string appenderName, Level threshold )
        {
          foreach (AppenderSkeleton appender in LogManager.GetRepository ().GetAppenders ())
          {
            if (appender.Name == appenderName)
            {
              appender.Threshold = threshold;
              appender.ActivateOptions ();
    
              break;
            }
          }
        } //eof method 
    
    
    
      } //eof class 
    
    
    } //eof namespace 
    
    USE [DBGA_DEV]
    GO
    
    /****** Object:  Table [ga].[tb_Data_Log]    Script Date: 05/20/2009 12:16:01 ******/
    SET ANSI_NULLS ON
    GO
    
    SET QUOTED_IDENTIFIER ON
    GO
    
    SET ANSI_PADDING ON
    GO
    
    CREATE TABLE [ga].[tb_Data_Log](
    	[ID] [int] IDENTITY(1,1) NOT NULL,
    	[Date] [datetime] NOT NULL,
    	[Thread] [varchar](255) NOT NULL,
    	[Level] [varchar](20) NOT NULL,
    	[Logger] [varchar](255) NOT NULL,
    	[Message] [varchar](4000) NOT NULL
    ) ON [PRIMARY]
    
    GO
    
    SET ANSI_PADDING ON
    GO
    
    
    
