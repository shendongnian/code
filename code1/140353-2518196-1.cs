      public static void Dispose(this TypeBuilder tb)
            {
                if (tb == null)
                    return;
                Type tbType = typeof(TypeBuilder);
                FieldInfo tbMbList = tbType.GetField("m_listMethods", BindingFlags.Instance | BindingFlags.NonPublic); //List<MethodBuilder>
                FieldInfo tbDecType = tbType.GetField("m_DeclaringType", BindingFlags.Instance | BindingFlags.NonPublic);//TypeBuilder
                FieldInfo tbGenType = tbType.GetField("m_genTypeDef", BindingFlags.Instance | BindingFlags.NonPublic);//TypeBuilder
                FieldInfo tbDeclMeth = tbType.GetField("m_declMeth", BindingFlags.Instance | BindingFlags.NonPublic);//MethodBuilder
                FieldInfo tbMbCurMeth = tbType.GetField("m_currentMethod", BindingFlags.Instance | BindingFlags.NonPublic);//MethodBuilder
                FieldInfo tbMod = tbType.GetField("m_module", BindingFlags.Instance | BindingFlags.NonPublic);//ModuleBuilder
                FieldInfo tbGenTypeParArr = tbType.GetField("m_inst", BindingFlags.Instance | BindingFlags.NonPublic); //GenericTypeParameterBuilder[] 
    
                TypeBuilder tempDecType = tbDecType.GetValue(tb) as TypeBuilder;
                tempDecType.Dispose();
                tbDecType.SetValue(tb, null);
                tempDecType = tbGenType.GetValue(tb) as TypeBuilder;
                tempDecType.Dispose();
                tbDecType.SetValue(tb, null);
    
                MethodBuilder tempMeth = tbDeclMeth.GetValue(tb) as MethodBuilder;
                tempMeth.Dispose();
                tbDeclMeth.SetValue(tb,null);
                tempMeth = tbMbCurMeth.GetValue(tb) as MethodBuilder;
                tempMeth.Dispose();
                tbMbCurMeth.SetValue(tb, null);
    
                ArrayList mbList = tbMbList.GetValue(tb) as ArrayList;
                for (int i = 0; i < mbList.Count; i++)
                {
                    tempMeth = mbList[i] as MethodBuilder;
                    tempMeth.Dispose();
                    mbList[i] = null;
                }
                tbMbList.SetValue(tb, null);
    
                ModuleBuilder tempMod = tbMod.GetValue(tb) as ModuleBuilder;
                tempMod.Dispose();
                tbMod.SetValue(tb, null);
    
                tbGenTypeParArr.SetValue(tb, null);
            }
            public static void Dispose(this MethodBuilder mb)
            {
                if (mb == null)
                    return;
                Type mbType = typeof(MethodBuilder);
                FieldInfo mbILGen = mbType.GetField("m_ilGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
                //FieldInfo mbIAttr = mbType.GetField("m_iAttributes", BindingFlags.Instance | BindingFlags.NonPublic);
                FieldInfo mbMod = mbType.GetField("m_module", BindingFlags.Instance | BindingFlags.NonPublic); //ModuleBuilder 
                FieldInfo mbContType = mbType.GetField("m_containingType", BindingFlags.Instance | BindingFlags.NonPublic);
                FieldInfo mbLocSigHelp = mbType.GetField("m_localSignature", BindingFlags.Instance | BindingFlags.NonPublic);//SignatureHelper
                FieldInfo mbSigHelp = mbType.GetField("m_signature", BindingFlags.Instance | BindingFlags.NonPublic);//SignatureHelper
                
                ILGenerator tempIlGen = mbILGen.GetValue(mb) as ILGenerator;
                tempIlGen.Dispose();
                SignatureHelper tempmbSigHelp = mbLocSigHelp.GetValue(mb) as SignatureHelper;
                tempmbSigHelp.Dispose();
                tempmbSigHelp = mbSigHelp.GetValue(mb) as SignatureHelper;
                tempmbSigHelp.Dispose();
    
                ModuleBuilder tempMod = mbMod.GetValue(mb) as ModuleBuilder;
                tempMod.Dispose();
                mbMod.SetValue(mb, null);
    
                mbILGen.SetValue(mb, null);
                mbContType.SetValue(mb, null);
                mbLocSigHelp.SetValue(mb, null);
                mbSigHelp.SetValue(mb, null);
                mbMod.SetValue(mb, null);
            }
            public static void Dispose(this SignatureHelper sh)
            {
                if (sh == null)
                    return;
                Type shType = typeof(SignatureHelper);
                FieldInfo shModule = shType.GetField("m_module", BindingFlags.Instance | BindingFlags.NonPublic);
                //FieldInfo shSig = shType.GetField("m_signature", BindingFlags.Instance | BindingFlags.NonPublic);
                shModule.SetValue(sh, null);
                //shSig.SetValue(sh, null);
            }
            public static void Dispose(this ILGenerator ilGen)
            {
                if (ilGen == null)
                    return;
                Type ilGenType = typeof(ILGenerator);
                FieldInfo ilSigHelp = ilGenType.GetField("m_localSignature", BindingFlags.Instance | BindingFlags.NonPublic);//SignatureHelper
                SignatureHelper sigTemp = ilSigHelp.GetValue(ilGen) as SignatureHelper;
                sigTemp.Dispose();
                ilSigHelp.SetValue(ilGen, null);
            }
            public static void Dispose(this ModuleBuilder modBuild)
            {
                if (modBuild == null)
                    return;
                Type modBuildType = typeof(ModuleBuilder);
                FieldInfo modBuildModData = modBuildType.GetField("m__moduleData", BindingFlags.Instance | BindingFlags.NonPublic |BindingFlags.FlattenHierarchy );
                FieldInfo modTypeBuildList = modBuildType.GetField("m__TypeBuilderList", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                
                ArrayList modTypeList = modTypeBuildList.GetValue(modBuild) as ArrayList;
                if(modTypeList != null)
                {
                    for (int i = 0; i < modTypeList.Count; i++)
                    {
                        TypeBuilder tb = modTypeList[i] as TypeBuilder;
                        tb.Dispose();
                        modTypeList = null;
                    }
                    modTypeBuildList.SetValue(modBuild, null);
                }
                modBuildModData.SetValue(modBuild, null);
            }
