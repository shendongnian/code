    public static class IisIntegration
    {
        private static object _oIpSecurity;
        private static Type _typeIpSecurityType;
        /// <summary>
        /// Sets IP|Domain into SMTP Server
        /// This method is used to insert one IP or DNS entry into the Relay Restriction List in IIS
        /// </summary>
        /// <param name="sMetabasePath">IIS://localhost/smtpsvc/1</param>
        /// <param name="sMethodName">Get|Put</param>
        /// <param name="sMethodArgument">IPSecurity|RelayIPList</param>
        /// <param name="sMember">IPGrant|IPDeny|DomainGrant|DomainDeny</param>
        /// <param name="item">IP|Domain</param>
        /// <param name="listCurrent">List of current IP(s)|Domain(s)</param>
        /// <param name="aListNew">List of new IP(s)|Domain(s)</param>
        /// <returns></returns>
        public static Boolean SetIpSecurityPropertySingle(String sMetabasePath, String sMethodName, String sMethodArgument, String sMember, String item, out List<EntityIpDomain> listCurrent, out List<EntityIpDomain> aListNew)
        {
            aListNew = null;
            DirectoryEntry directoryEntry = new DirectoryEntry(sMetabasePath);
            directoryEntry.RefreshCache();
            _oIpSecurity = directoryEntry.Invoke(sMethodName, new[] { sMethodArgument });
            _typeIpSecurityType = _oIpSecurity.GetType();
            //retrieve array of IP(s)|Domain(s)
            Array aDataCurrent = GetIpSecurityData(_oIpSecurity, _typeIpSecurityType, sMember);
            //log entry
            Boolean bExists = ListIpDomainAndCheckIfNewExists(aDataCurrent, item);
            //convert array to list
            listCurrent = ConvertArrayToList(aDataCurrent);
            if (!bExists)
            {
                //instantiate new instance of object dataCurrent
                Object[] oNewData = new object[aDataCurrent.Length + 1];
                //copy dataCurrent into newData
                aDataCurrent.CopyTo(oNewData, 0);
                //add the new value to the newData object
                oNewData.SetValue(item, aDataCurrent.Length);
                //invokes the specified sMember using the arguments supplied
                _typeIpSecurityType.InvokeMember(sMember, BindingFlags.SetProperty, null, _oIpSecurity, new object[] { oNewData });
                //invokes the arguments of the method
                directoryEntry.Invoke("Put", new[] { sMethodArgument, _oIpSecurity });
                //commits the changes
                directoryEntry.CommitChanges();
                //refreshes the cache
                directoryEntry.RefreshCache();
                //return the new list of IP(s)|Domain(s)
                _oIpSecurity = directoryEntry.Invoke("Get", new[] { sMethodArgument });
                Array aDataNew = (Array)_typeIpSecurityType.InvokeMember(sMember, BindingFlags.GetProperty, null, _oIpSecurity, null);
                //log entry
                bExists = ListIpDomainAndCheckIfNewExists(aDataNew, item);
                aListNew = ConvertArrayToList(aDataNew);
            }
            return bExists;
        }
        /// <summary>
        /// Set IP(s)|Domain(s) into SMTP Server
        /// This method is used to insert multiple IPs or DNS entries into the Relay Restriction List in IIS
        /// </summary>
        /// <param name="sMetabasePath">IIS://localhost/smtpsvc/1</param>
        /// <param name="sMethodName">Get|Put</param>
        /// <param name="sMethodArgument">IPSecurity|RelayIPList</param>
        /// <param name="sMember">IPGrant|IPDeny|DomainGrant|DomainDeny</param>
        /// <param name="list">List of IP(s)\Domain(s)</param>
        public static Boolean SetIpSecurityPropertyArray(String sMetabasePath, String sMethodName, String sMethodArgument, String sMember, List<EntityIpDomain> list)
        {
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry(sMetabasePath);
                directoryEntry.RefreshCache();
                //return result of Invoke method
                _oIpSecurity = directoryEntry.Invoke(sMethodName, new[] { sMethodArgument });
                //get Type of ipSecurity
                Type typeIpSecurityType = _oIpSecurity.GetType();
                Object[] newList = new object[list.Count];
                Int32 iCounter = 0;
                foreach (EntityIpDomain item in list)
                {
                    newList[iCounter] = item.IpDomain;
                    iCounter++;
                }
                // add the updated list back to the IPSecurity object
                typeIpSecurityType.InvokeMember(sMember, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, _oIpSecurity, new object[] { newList });
                directoryEntry.Properties[sMethodArgument][0] = _oIpSecurity;
                // commit the changes
                directoryEntry.CommitChanges();
                directoryEntry.RefreshCache();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Retrieves the IP(s)|Domain(s) from the SMTP Server in an Array
        /// This method retrieves teh IPs/DNS entries from the Relay Restriction List in IIS
        /// </summary>
        /// <param name="sMetabasePath">IIS://localhost/smtpsvc/1</param>
        /// <param name="sMethodName">Get|Put</param>
        /// <param name="sMethodArgument">IPSecurity|RelayIPList</param>
        /// <param name="sMember">IPGrant|IPDeny|DomainGrant|DomainDeny</param>
        /// <returns></returns>
        public static List<EntityIpDomain> GetIpSecurityPropertyArray(String sMetabasePath, String sMethodName, String sMethodArgument, String sMember)
        {
            //instantiates an instance of DirectoryEntry
            DirectoryEntry directoryEntry = new DirectoryEntry(sMetabasePath);
            directoryEntry.RefreshCache();
            //return result of Invoke method
            object oIpSecurity = directoryEntry.Invoke(sMethodName, new[] { sMethodArgument });
            //get Type of ipSecurity
            Type typeIpSecurityType = oIpSecurity.GetType();
            //returns an array of IPS or Domains
            Array data = GetIpSecurityData(oIpSecurity, typeIpSecurityType, sMember);
            //load the array into a generic list
            List<EntityIpDomain> list = new List<EntityIpDomain>();
            for (int i = 0; i < data.Length; i++)
            {
                EntityIpDomain entityIpDomain = new EntityIpDomain();
                entityIpDomain.IpDomain = data.GetValue(i).ToString();
                list.Add(entityIpDomain);
            }
            return list;
        }
        /// <summary>
        /// Retrieves a list of IPs or Domains
        /// //This is a helper method that actually returns an array of IPs/DNS entries from the Relay Restricton List in IIS
        /// </summary>
        /// <param name="oIpSecurity">Result of directoryEntry.Invoke</param>
        /// <param name="tIpSecurityType">Type of oIpSecurity</param>
        /// <param name="sMember">IPGrant|IPDeny|DomainGrant|DomainDeny</param>
        /// <returns>Array of IP(s)|Domain(s)</returns>
        private static Array GetIpSecurityData(object oIpSecurity, Type tIpSecurityType, String sMember)
        {
            return (Array)tIpSecurityType.InvokeMember(sMember, BindingFlags.GetProperty, null, oIpSecurity, null);
        }
        /// <summary>
        /// Lists the IP(s)|Domain(s)
        /// </summary>
        /// <param name="aData">Array of IP(s)|Domain(s)</param>
        /// <param name="sItem"></param>
        /// <returns>Stringbuilder of the list</returns>
        private static Boolean ListIpDomainAndCheckIfNewExists(Array aData, String sItem)
        {
            Boolean bExists = false;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (object oDataItem in aData)
            {
                stringBuilder.Append(oDataItem + Environment.NewLine);
                if (oDataItem.ToString().StartsWith(sItem))
                {
                    bExists = true;
                }
            }
            return bExists;
        }
        /// <summary>
        /// Converts an array to a Genreic List of Type EntityIpDomain
        /// This method converts the array to a list so I can pass it back in a WCF service
        /// </summary>
        /// <param name="aData">Array of IP(s)|Domain(s)</param>
        /// <returns>Generic List of Type EntityIpDomain</returns>
        private static List<EntityIpDomain> ConvertArrayToList(Array aData)
        {
            List<EntityIpDomain> list = new List<EntityIpDomain>(aData.Length);
            foreach (String item in aData)
            {
                EntityIpDomain ipDomainValue = new EntityIpDomain { IpDomain = item };
                list.Add(ipDomainValue);
            }
            return list;
        }
    }
