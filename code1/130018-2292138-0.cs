    Imports Castle.ActiveRecord
    imports NHibernate.Expression
    
    <ActiveRecord> _
    Public Class Test1
    	Inherits ActiveRecordBase(Of Test1)
    	
    	Private _id As Guid
    	<PrimaryKeyAttribute(PrimaryKeyType.Guid)> _
    	Public overridable Property Id as Guid
    		Get
    			return _id
    		End Get
    		
    		Set(value As guid)
    			_id = value
    		End Set
    	End Property
    	
    	
    	Private _prop1 As String
    	<[Property]> _
    	Public overridable Property prop1 as String
    		Get
    			return _prop1
    		End Get
    		
    		Set(value As String)
    			_prop1 = value
    		End Set
    	End Property
    	
    End Class
    
    <ActiveRecord> _
    Public Class Test2
    	Inherits ActiveRecordBase(Of Test2)
    	
    	Private _id As Guid
    	<PrimaryKey(PrimaryKeyType.Guid)> _
    	Public overridable Property Id as Guid
    		Get
    			return _id
    		End Get
    		
    		Set(value As guid)
    			_id = value
    		End Set
    	End Property
    	
    	Private _prop1 As String
    	<[Property]> _
    	Public overridable Property prop1 as String
    		Get
    			return _prop1
    		End Get
    		
    		Set(value As String)
    			_prop1 = value
    		End Set
    	End Property
    	
    	Private _t1 As Test1
    	<BelongsTo()> _
    	Public overridable Property t1 as Test1
    		Get
    			return _t1
    		End Get
    		
    		Set(value As test1)
    			_t1 = value
    		End Set
    	End Property
    	
    	
    End Class
----------
    Imports Castle.ActiveRecord
    Imports NHibernate.Expression
    Imports System.Data.SqlClient
    Imports System.Transactions
    imports System.Configuration
    
    Public Module Module1
    	Public Class modMain
    		Public Shared Sub Main()
    			Castle.ActiveRecord.ActiveRecordStarter.Initialize()
    			Using T As New System.Transactions.TransactionScope(ondispose.Rollback)
    			Dim x As New Test1()
    			x.prop1 = "Hello"
    			x.Save
    			
    			using c As New SqlConnection()
    				c.ConnectionString = ConfigurationManager.ConnectionStrings("Development").ConnectionString
    				Dim cmd As SqlCommand = c.CreateCommand()
    				cmd.CommandText = "insert into test2(prop1, t1) values(@prop1, @t1)"
    				Dim p As SqlParameter = cmd.CreateParameter()
    				p.Direction = parameterdirection.Input
    				p.DbType = dbtype.Guid
    				p.ParameterName = "@prop1"
    				p.Value = "Test"
    				
    				cmd.Parameters.Add(p)
    				p = cmd.CreateParameter()
    				p.Direction = parameterdirection.Input
    				p.DbType = dbtype.Guid
    				p.ParameterName = "@t1"
    				p.Value = x.Id
    				
    				c.Open
    				cmd.ExecuteNonQuery
    			end using
    			
    			t.Complete
    			end using
    			
    		End Sub
    	End Class
    End Module
