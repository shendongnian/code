    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Reflection.Emit;
     
    public static class SqlDataReaderExtensions {
    
       private delegate int IndexOfDelegate(SqlDataReader reader, string name);
       private static IndexOfDelegate IndexOf;
    
       public static int GetColumnIndex(this SqlDataReader reader, string name) {
          return name == null ? -1 : IndexOf(reader, name);
       }
    
       public static bool ContainsColumn(this SqlDataReader reader, string name) {
          return name != null && IndexOf(reader, name) >= 0;
       }
    
       static SqlDataReaderExtensions() {
          Type typeSqlDataReader = typeof(SqlDataReader);
          Type typeSqlStatistics = typeSqlDataReader.Assembly.GetType("System.Data.SqlClient.SqlStatistics", true);
          Type typeFieldNameLookup = typeSqlDataReader.Assembly.GetType("System.Data.ProviderBase.FieldNameLookup", true);
    
          BindingFlags staticflags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Static;
          BindingFlags instflags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;
    
          DynamicMethod dynmethod = new DynamicMethod("SqlDataReader_IndexOf", typeof(int), new Type[2]{ typeSqlDataReader, typeof(string) }, true);
          ILGenerator gen = dynmethod.GetILGenerator();
          gen.DeclareLocal(typeSqlStatistics);
          gen.DeclareLocal(typeof(int));
    
          // SqlStatistics statistics = (SqlStatistics) null;
          gen.Emit(OpCodes.Ldnull);
          gen.Emit(OpCodes.Stloc_0);
          // try {
          gen.BeginExceptionBlock();
          //    statistics = SqlStatistics.StartTimer(this.Statistics);
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Call, typeSqlDataReader.GetProperty("Statistics", instflags | BindingFlags.GetProperty, null, typeSqlStatistics, Type.EmptyTypes, null).GetMethod);
          gen.Emit(OpCodes.Call, typeSqlStatistics.GetMethod("StartTimer", staticflags | BindingFlags.InvokeMethod, null, new Type[] { typeSqlStatistics }, null));
          gen.Emit(OpCodes.Stloc_0); //statistics
          //    if(this._fieldNameLookup == null) {
          Label branchTarget = gen.DefineLabel();
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Ldfld, typeSqlDataReader.GetField("_fieldNameLookup", instflags | BindingFlags.GetField));
          gen.Emit(OpCodes.Brtrue_S, branchTarget);
          //       this.CheckMetaDataIsReady();
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Call, typeSqlDataReader.GetMethod("CheckMetaDataIsReady", instflags | BindingFlags.InvokeMethod, null, Type.EmptyTypes, null));
          //       this._fieldNameLookup = new FieldNameLookup((IDataRecord)this, this._defaultLCID);
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Ldfld, typeSqlDataReader.GetField("_defaultLCID", instflags | BindingFlags.GetField));
          gen.Emit(OpCodes.Newobj, typeFieldNameLookup.GetConstructor(instflags, null, new Type[] { typeof(IDataReader), typeof(int) }, null));
          gen.Emit(OpCodes.Stfld, typeSqlDataReader.GetField("_fieldNameLookup", instflags | BindingFlags.SetField));
          //    }
          gen.MarkLabel(branchTarget);
          gen.Emit(OpCodes.Ldarg_0); //this
          gen.Emit(OpCodes.Ldfld, typeSqlDataReader.GetField("_fieldNameLookup", instflags | BindingFlags.GetField));
          gen.Emit(OpCodes.Ldarg_1); //name
          gen.Emit(OpCodes.Call, typeFieldNameLookup.GetMethod("IndexOf", instflags | BindingFlags.InvokeMethod, null, new Type[] { typeof(string) }, null));
          gen.Emit(OpCodes.Stloc_1); //int output
          Label leaveProtectedRegion = gen.DefineLabel();
          gen.Emit(OpCodes.Leave_S, leaveProtectedRegion);
          // } finally {
          gen.BeginFaultBlock();
          //    SqlStatistics.StopTimer(statistics);
          gen.Emit(OpCodes.Ldloc_0); //statistics
          gen.Emit(OpCodes.Call, typeSqlStatistics.GetMethod("StopTimer", staticflags | BindingFlags.InvokeMethod, null, new Type[] { typeSqlStatistics }, null));
          // }
          gen.EndExceptionBlock();
          gen.MarkLabel(leaveProtectedRegion);
          gen.Emit(OpCodes.Ldloc_1);
          gen.Emit(OpCodes.Ret);
    
          IndexOf = (IndexOfDelegate)dynmethod.CreateDelegate(typeof(IndexOfDelegate));
       }
    
    }
