    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Data.Common;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DynamicEnums
    {
      class EnumCreator
      {
        //after running for first time rename this method to Main1
        static void Main ()
        {
          string strAssemblyName = "MyEnums";
          bool flagFileExists = System.IO.File.Exists
            ( AppDomain.CurrentDomain.SetupInformation.ApplicationBase + strAssemblyName + ".dll" );
    
          // Get the current application domain for the current thread
          AppDomain currentDomain = AppDomain.CurrentDomain;
    
          // Create a dynamic assembly in the current application domain,
          // and allow it to be executed and saved to disk.
          AssemblyName name = new AssemblyName ( strAssemblyName );
          AssemblyBuilder assemblyBuilder = currentDomain.DefineDynamicAssembly ( name,
                                                AssemblyBuilderAccess.RunAndSave );
    
          // Define a dynamic module in "MyEnums" assembly.
          // For a single-module assembly, the module has the same name as the assembly.
          ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule ( name.Name,
                                            name.Name + ".dll" );
    
          // Define a public enumeration with the name "MyEnum" and an underlying type of Integer.
          EnumBuilder myEnum = moduleBuilder.DefineEnum ( "EnumeratedTypes.MyEnum",
                                   TypeAttributes.Public, typeof ( int ) );
    
          #region GetTheDataFromTheDatabase
          DataTable tableData = new DataTable ( "enumSourceDataTable" );
    
          string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ocms_dev;Data Source=ysg";
    
          using (SqlConnection connection = new SqlConnection ( connectionString ))
          {
    
            SqlCommand command = connection.CreateCommand ();
    
            command.CommandText = string.Format ( "SELECT [RoleId],[RoleName] FROM [ocms_dev].[dbo].[Role]" );
            Console.WriteLine ( "command.CommandText is " + command.CommandText );
            connection.Open ();
            tableData.Load ( command.ExecuteReader ( CommandBehavior.CloseConnection ) );
          } //eof using
    
          foreach (DataRow dr in tableData.Rows)
          {
            myEnum.DefineLiteral ( dr[1].ToString (), Convert.ToInt32 ( dr[0].ToString () ) );
          }
          #endregion GetTheDataFromTheDatabase
    
          // Create the enum
          myEnum.CreateType ();
    
          // Finally, save the assembly
          assemblyBuilder.Save ( name.Name + ".dll" );
    
         
    
        } //eof Main 
    
      } //eof Program
     } //eof namespace 
