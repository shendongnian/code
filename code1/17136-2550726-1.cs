    using System;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    
    namespace DbExtensions {
       
       public static class Db {
    
          static readonly MethodInfo getParameterName;
          static readonly MethodInfo getParameterPlaceholder;
          static readonly PropertyInfo dbProviderFactory;
    
          static Db() {
             getParameterName = typeof(DbCommandBuilder).GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(Int32) }, null);
             getParameterPlaceholder = typeof(DbCommandBuilder).GetMethod("GetParameterPlaceholder", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(Int32) }, null);
             dbProviderFactory = typeof(DbConnection).GetProperty("DbProviderFactory", BindingFlags.Instance | BindingFlags.NonPublic);
          }
    
          public static DbProviderFactory GetProviderFactory(this DbConnection connection) {
             return (DbProviderFactory)dbProviderFactory.GetValue(connection, null);
          }
    
          public static DbCommand CreateCommand(this DbConnection connection, string commandText, params object[] parameters) {
             if (connection == null) throw new ArgumentNullException("connection");
    
             return SetUpCommand(GetProviderFactory(connection).CreateCommandBuilder(), connection.CreateCommand(), commandText, parameters);
          }
    
          private static DbCommand SetUpCommand(DbCommandBuilder commandBuilder, DbCommand command, string commandText, params object[] parameters) {
    
             if (commandBuilder == null) throw new ArgumentNullException("commandBuilder");
             if (command == null) throw new ArgumentNullException("command");
             if (commandText == null) throw new ArgumentNullException("commandText");
    
             if (parameters == null || parameters.Length == 0) {
                command.CommandText = commandText;
                return command;
             }
    
             string[] paramPlaceholders = (string[])Array.CreateInstance(typeof(string), parameters.Length);
    
             for (int i = 0; i < paramPlaceholders.Length; i++) {
    
                DbParameter dbParam = command.CreateParameter();
                dbParam.ParameterName = (string)getParameterName.Invoke(commandBuilder, new object[] { i });
                dbParam.Value = parameters[i] ?? DBNull.Value;
                command.Parameters.Add(dbParam);
    
                paramPlaceholders[i] = (string)getParameterPlaceholder.Invoke(commandBuilder, new object[] { i });
             }
    
             command.CommandText = string.Format(CultureInfo.InvariantCulture, commandText, paramPlaceholders);
    
             return command;
          }
       }
    }
