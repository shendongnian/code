    public void Function()
    {
        CimInstance QueryInstance(CimSession session, string cimNamespace, string query)
        {
            IEnumerable<CimInstance> queryInstances = session.QueryInstances(cimNamespace, "WQL", query);
            return queryInstances.FirstOrDefault();
        }
        byte[] BuildObjectSid(string sid)
        {
            SecurityIdentifier securityIdentifier = new SecurityIdentifier(sid);
            byte[] bytes = new byte[securityIdentifier.BinaryLength];
            securityIdentifier.GetBinaryForm(bytes, 0);
            return bytes;
        }
        string computerName = "localhost";
        string namespaceName = @"root\cimv2";
        string oldGroup = "Everyone";
        string newGroup = "Not Everyone";
        string newGroupSidString = "S-1-5-21";
        byte[] newGroupSid = BuildObjectSid(newGroupSidString);
        DComSessionOptions sessionOptions = new DComSessionOptions
        {
            Timeout = new TimeSpan(0, 2, 0)
        };
        CimSession cimSession = CimSession.Create(computerName, sessionOptions);
        CimInstance trustee = new CimInstance(cimSession.GetClass(namespaceName, "Win32_Trustee"));
        trustee.CimInstanceProperties["Domain"].Value = "GLOBAL";
        trustee.CimInstanceProperties["Name"].Value = newGroup;
        trustee.CimInstanceProperties["SIDString"].Value = newGroupSidString;
        trustee.CimInstanceProperties["SID"].Value = newGroupSid;
        trustee.CimInstanceProperties["SidLength"].Value = newGroupSid.Length;
        CimInstance newAce = new CimInstance(cimSession.GetClass(namespaceName, "Win32_ACE"));
        newAce.CimInstanceProperties["AccessMask"].Value = 1179817;
        newAce.CimInstanceProperties["AceFlags"].Value = 3;
        newAce.CimInstanceProperties["AceType"].Value = 0;
        newAce.CimInstanceProperties["Trustee"].Value = trustee;
        string lfsQuery = @"select * from Win32_LogicalFileSecuritySetting where Path='C:\\dev\\temp\\wmi'";
        CimInstance logicalFileSecSetting = QueryInstance(cimSession, namespaceName, lfsQuery);
        CimClass cimClass = cimSession.GetClass(namespaceName, "Win32_LogicalFileSecuritySetting");
        CimMethodResult methodResult;
        methodResult = cimSession.InvokeMethod(namespaceName, logicalFileSecSetting, "GetSecurityDescriptor", new CimMethodParametersCollection());
        CimInstance descriptor = (CimInstance)methodResult.OutParameters["Descriptor"].Value;
        CimInstance[] aces = (CimInstance[])descriptor.CimInstanceProperties["DACL"].Value;
        for (int i = 0; i < aces.Length; i++)
        {
            CimInstance aceTrustee = (CimInstance)aces[i].CimInstanceProperties["Trustee"].Value;
            string aceTrusteeName = (string)aceTrustee.CimInstanceProperties["Name"].Value;
            if (aceTrusteeName == oldGroup)
            {
                aces[i] = newAce;
            }
        }
        descriptor.CimInstanceProperties["DACL"].Value = aces;
        CimInstance cimDirectory = QueryInstance(cimSession, namespaceName, @"SELECT * FROM Cim_Directory WHERE Name='C:\\dev\\temp\\wmi'");
        CimMethodParametersCollection methodParameters = new CimMethodParametersCollection
        {
            CimMethodParameter.Create("SecurityDescriptor", descriptor, CimType.Instance, CimFlags.In),
            CimMethodParameter.Create("Option", 4, CimType.UInt32, CimFlags.In)
        };
        methodResult = cimSession.InvokeMethod(namespaceName, cimDirectory, "ChangeSecurityPermissions", methodParameters);
    }
