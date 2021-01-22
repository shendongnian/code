    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using log4net;
    using log4net.Config;
    using NUnit.Framework;
    
    namespace ExampleConsoleApplication
    {
    	[TestFixture]
    	class TestClass
    	{
    
        //private static readonly ILog logger =
        //     LogManager.GetLogger ( typeof ( TestClass ) );
    
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger ( System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType );
    
    		static void Main ( string[] args )
    		{
    
    			Console.WriteLine ( " START " );
    			#region LoggerUsage
    			DOMConfigurator.Configure (); //tis configures the logger 
    			logger.Debug ( "Here is a debug log." );
    			logger.Info ( "... and an Info log." );
    			logger.Warn ( "... and a warning." );
    			logger.Error ( "... and an error." );
    			logger.Fatal ( "... and a fatal error." );
          
    			#endregion LoggerUsage
    			TestClass objTestClass = new TestClass();
    			objTestClass.TestMethodNameOK ();
    			objTestClass.TestMethodNameNOK ();
    
    			Console.WriteLine ( " END HIT A KEY TO EXIT " );
    			Console.ReadLine ();
    			} //eof method 
    
    		[SetUp]
    		protected void SetUp ()
    		{
    			//Add Here the Initialization of the objects 
    		}
    		[Test ( Description = "Add here the description of this test method " )]
    		protected void TestMethodNameOK ()
    		{ 
    			//build ok use case scenario here - e.g. no exception should be raced '
    			//Vegetable newCarrot = pool.GetItemByPropertyValue<Vegetable> ( "WriongByPurpose", "Orange" );
    			//Assert.IsInstanceOfType ( typeof ( Vegetable ), newCarrot );
    			//Assert.AreSame ( newCarrot, carrot );
    			//logger.Info ( " I got the newCarrot which is " + newCarrot.Color );
    
    		} //eof method 
    
    		[Test ( Description = "Add here the description of this test method " )]
    		protected void TestMethodNameNOK ()			//e.g. the one that should raze Exception
    		{
    			//build ok use case scenario here - e.g. no exception should be raced '
    			//Vegetable newCarrot = pool.GetItemByPropertyValue<Vegetable> ( "WriongByPurpose", "Orange" );
    			//Assert.IsInstanceOfType ( typeof ( Vegetable ), newCarrot );
    			//Assert.AreSame ( newCarrot, carrot );
    			//logger.Info ( " I got the newCarrot which is " + newCarrot.Color );
    
    		} //eof method 
    
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
    			<param name="File" value="Program.log" />
    			<param name="AppendToFile" value="true" />
    			<layout type="log4net.Layout.PatternLayout">
            <!--<param name="Header" value="======================================" />
            <param name="Footer" value="======================================" />-->
            <param name="ConversionPattern" value="%d [%t] %-5p - %m%n" />
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
    #endregion TheAppconfig
     //this is the xml added replace here your log4net and Nunit paths
    //<Reference Include="log4net, Version=1.2.10.0, Culture=neutral, PublicKeyToken=1b44e1d426115821, processorArchitecture=MSIL">
    		//  <SpecificVersion>False</SpecificVersion>
    		//  <HintPath>..\..\..\Log4Net\log4net-1.2.10\bin\net\2.0\release\log4net.dll</HintPath>
    		//</Reference>
    		//<Reference Include="nunit.framework, Version=2.4.8.0, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL" />
