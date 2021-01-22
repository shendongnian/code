    using System.Threading;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    
    static class DataTableExtensions
    {
        
       
        public static Type GetTableType(DataTable DTable)
        {
            
            // Create needed TypeBuilder helpers
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName myAsmName = new AssemblyName("Anonymous");
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            
            ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(myAsmName.Name);
            TypeBuilder myTypeBuilder = myModBuilder.DefineType(DTable.TableName, TypeAttributes.Public);
            
            foreach (DataColumn col in DTable.Columns) {
                
                var PropertyName = col.ColumnName;
                var PropertyType = col.DataType;
                
                FieldBuilder PropertyFieldBuilder = myTypeBuilder.DefineField("_" + PropertyName.ToLower, PropertyType, FieldAttributes.Private);
                
                PropertyBuilder PBuilder = myTypeBuilder.DefineProperty(PropertyName, PropertyAttributes.HasDefault, col.DataType, null);
                
                MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
                
                MethodBuilder getPropertyBuilder = myTypeBuilder.DefineMethod("get" + PropertyName, getSetAttr, col.DataType, Type.EmptyTypes);
                
                // Constructing IL Code for get and set Methods.
                ILGenerator GetPropGenerator = getPropertyBuilder.GetILGenerator();
                
                GetPropGenerator.Emit(OpCodes.Ldarg_0);
                GetPropGenerator.Emit(OpCodes.Ldfld, PropertyFieldBuilder);
                GetPropGenerator.Emit(OpCodes.Ret);
                
                MethodBuilder setPropertyBuulder = myTypeBuilder.DefineMethod("set_" + PropertyName, getSetAttr, null, new Type[] { col.DataType });
                
                ILGenerator SetPropGenerator = setPropertyBuulder.GetILGenerator();
                
                SetPropGenerator.Emit(OpCodes.Ldarg_0);
                SetPropGenerator.Emit(OpCodes.Ldarg_1);
                SetPropGenerator.Emit(OpCodes.Stfld, PropertyFieldBuilder);
                SetPropGenerator.Emit(OpCodes.Ret);
                
                PBuilder.SetGetMethod(getPropertyBuilder);
                    
                PBuilder.SetSetMethod(setPropertyBuulder);
            }
            
            ConstructorInfo objCtor = typeof(object).GetConstructor(new Type[-1 + 1]);
            ConstructorBuilder pointCtor = myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            
            ILGenerator ctorIL = pointCtor.GetILGenerator();
            
            // Constructing IL Code for the Type Constructor.
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, objCtor);
            ctorIL.Emit(OpCodes.Ret);
            
                
            return myTypeBuilder.CreateType();
        }
        
     
    }
