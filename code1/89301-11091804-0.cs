    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace UnmanagedCode
    {
        public class PInvoke
        {
            #region Constants
            public const int ERROR_SUCCESS = 0;
            public const int ERROR_BUFFER_OVERFLOW = 111;
            #endregion Constants
            #region DN Parsing
            [DllImport("ntdsapi.dll", CharSet = CharSet.Unicode)]
            protected static extern int DsGetRdnW(
                ref IntPtr ppDN, 
                ref int pcDN, 
                out IntPtr ppKey, 
                out int pcKey, 
                out IntPtr ppVal, 
                out int pcVal
            );
            public static KeyValuePair<string, string> GetName(string distinguishedName)
            {
                IntPtr pDistinguishedName = Marshal.StringToHGlobalUni(distinguishedName);
                try
                {
                    IntPtr pDN = pDistinguishedName, pKey, pVal;
                    int cDN = distinguishedName.Length, cKey, cVal;
                    int lastError = DsGetRdnW(ref pDN, ref cDN, out pKey, out cKey, out pVal, out cVal);
                    if(lastError == ERROR_SUCCESS)
                    {
                        string key, value;
                        if(cKey < 1)
                        {
                            key = string.Empty;
                        }
                        else
                        {
                            key = Marshal.PtrToStringUni(pKey, cKey);
                        }
                        if(cVal < 1)
                        {
                            value = string.Empty;
                        }
                        else
                        {
                            value = Marshal.PtrToStringUni(pVal, cVal);
                        }
                        return new KeyValuePair<string, string>(key, value);
                    }
                    else
                    {
                        throw new Win32Exception(lastError);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(pDistinguishedName);
                }
            }
            public static IEnumerable<KeyValuePair<string, string>> ParseDN(string distinguishedName)
            {
                List<KeyValuePair<string, string> components = new List<KeyValuePair<string, string>>();
                IntPtr pDistinguishedName = Marshal.StringToHGlobalUni(distinguishedName);
                try
                {
                    IntPtr pDN = pDistinguishedName, pKey, pVal;
                    int cDN = distinguishedName.Length, cKey, cVal;
                    do
                    {
                        int lastError = DsGetRdnW(ref pDN, ref cDN, out pKey, out cKey, out pVal, out cVal);
                        if(lastError = ERROR_SUCCESS)
                        {
                            string key, value;
                            if(cKey < 0)
                            {
                                key = null;
                            }
                            else if(cKey == 0)
                            {
                                key = string.Empty;
                            }
                            else
                            {
                                key = Marshal.PtrToStringUni(pKey, cKey);
                            }
                            if(cVal < 0)
                            {
                                value = null;
                            }
                            else if(cVal == 0)
                            {
                                value = string.Empty;
                            }
                            else
                            {
                                value = Marshal.PtrToStringUni(pVal, cVal);
                            }
                            components.Add(new KeyValuePair<string, string>(key, value));
                            pDN = (IntPtr)(pDN.ToInt64() + UnicodeEncoding.CharSize); //skip over comma
                            cDN--;
                        }
                        else
                        {
                            throw new Win32Exception(lastError);
                        }
                    } while(cDN > 0);
                    return components;
                }
                finally
                {
                    Marshal.FreeHGlobal(pDistinguishedName);
                }
            }
            [DllImport("ntdsapi.dll", CharSet = CharSet.Unicode)]
            protected static extern int DsQuoteRdnValueW(
                int cUnquotedRdnValueLength,
                string psUnquotedRdnValue,
                ref int pcQuotedRdnValueLength,
                IntPtr psQuotedRdnValue
            );
            public static string QuoteRDN(string rdn)
            {
                if (rdn == null) return null;
                int initialLength = rdn.Length;
                int quotedLength = 0;
                IntPtr pQuotedRDN = IntPtr.Zero;
                int lastError = DsQuoteRdnValueW(initialLength, rdn, ref quotedLength, pQuotedRDN);
                switch (lastError)
                {
                    case ERROR_SUCCESS:
                        {
                            return string.Empty;
                        }
                    case ERROR_BUFFER_OVERFLOW:
                        {
                            break; //continue
                        }
                    default:
                        {
                            throw new Win32Exception(lastError);
                        }
                }
                pQuotedRDN = Marshal.AllocHGlobal(quotedLength * UnicodeEncoding.CharSize);
                try
                {
                    lastError = DsQuoteRdnValueW(initialLength, rdn, ref quotedLength, pQuotedRDN);
                    switch(lastError)
                    {
                        case ERROR_SUCCESS:
                            {
                                return Marshal.PtrToStringUni(pQuotedRDN, quotedLength);
                            }
                        default:
                            {
                                throw new Win32Exception(lastError);
                            }
                    }
                }
                finally
                {
                    if(pQuotedRDN != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(pQuotedRDN);
                    }
                }
            }
            [DllImport("ntdsapi.dll", CharSet = CharSet.Unicode)]
            protected static extern int DsUnquoteRdnValueW(
                int cQuotedRdnValueLength,
                string psQuotedRdnValue,
                ref int pcUnquotedRdnValueLength,
                IntPtr psUnquotedRdnValue
            );
            public static string UnquoteRDN(string rdn)
            {
                if (rdn == null) return null;
                int initialLength = rdn.Length;
                int unquotedLength = 0;
                IntPtr pUnquotedRDN = IntPtr.Zero;
                int lastError = DsUnquoteRdnValueW(initialLength, rdn, ref unquotedLength, pUnquotedRDN);
                switch (lastError)
                {
                    case ERROR_SUCCESS:
                        {
                            return string.Empty;
                        }
                    case ERROR_BUFFER_OVERFLOW:
                        {
                            break; //continue
                        }
                    default:
                        {
                            throw new Win32Exception(lastError);
                        }
                }
                pUnquotedRDN = Marshal.AllocHGlobal(unquotedLength * UnicodeEncoding.CharSize);
                try
                {
                    lastError = DsUnquoteRdnValueW(initialLength, rdn, ref unquotedLength, pUnquotedRDN);
                    switch(lastError)
                    {
                        case ERROR_SUCCESS:
                            {
                                return Marshal.PtrToStringUni(pUnquotedRDN, unquotedLength);
                            }
                        default:
                            {
                                throw new Win32Exception(lastError);
                            }
                    }
                }
                finally
                {
                    if(pUnquotedRDN != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(pUnquotedRDN);
                    }
                }
            }
            #endregion DN Parsing
        }
        public class DNComponent
        {
            public string Type { get; protected set; }
            public string EscapedValue { get; protected set; }
            public string UnescapedValue { get; protected set; }
            public string WholeComponent { get; protected set; }
            
            public DNComponent(string component, bool isEscaped)
            {
                string[] tokens = component.Split(new char[] { '=' }, 2);
                setup(tokens[0], tokens[1], isEscaped);
            }
            public DNComponent(string key, string value, bool isEscaped)
            {
                setup(key, value, isEscaped);
            }
            private void setup(string key, string value, bool isEscaped)
            {
                Type = key;
                if(isEscaped)
                {
                    EscapedValue = value;
                    UnescapedValue = PInvoke.UnquoteRDN(value);
                }
                else
                {
                    EscapedValue = PInvoke.QuoteRDN(value);
                    UnescapedValue = value;
                }
                WholeComponent = Type + "=" + EscapedValue;
            }
            public override bool Equals(object obj)
            {
                if (obj is DNComponent)
                {
                    DNComponent dnObj = (DNComponent)obj;
                    return dnObj.WholeComponent.Equals(this.WholeComponent, StringComparison.CurrentCultureIgnoreCase);
                }
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return WholeComponent.GetHashCode();
            }
        }
        public class DistinguishedName
        {
            public DNComponent[] Components
            {
                get
                {
                    return components.ToArray();
                }
            }
            private List<DNComponent> components;
            private string cachedDN;
            public DistinguishedName(string distinguishedName)
            {
                cachedDN = distinguishedName;
                components = new List<DNComponent>();
                foreach (KeyValuePair<string, string> kvp in PInvoke.ParseDN(distinguishedName))
                {
                    components.Add(new DNComponent(kvp.Key, kvp.Value, true));
                }
            }
            public DistinguishedName(IEnumerable<DNComponent> dnComponents)
            {
                components = new List<DNComponent>(dnComponents);
                cachedDN = GetWholePath(",");
            }
            public bool Contains(DNComponent dnComponent)
            {
                return components.Contains(component);
            }
            public string GetDNSDomainName()
            {
                List<string> dcs = new List<string>();
                foreach (DNComponent dnc in components)
                {
                    if(dnc.Type.Equals("DC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dcs.Add(dnc.UnescapedValue);
                    }
                }
                return string.Join(".", dcs.ToArray());
            }
            public string GetDomainDN()
            {
                List<string> dcs = new List<string>();
                foreach (DNComponent dnc in components)
                {
                    if(dnc.Type.Equals("DC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dcs.Add(dnc.WholeComponent);
                    }
                }
                return string.Join(",", dcs.ToArray());
            }
            public string GetWholePath()
            {
                return GetWholePath(",");
            }
            public string GetWholePath(string separator)
            {
                List<string> parts = new List<string>();
                foreach (DNComponent component in components)
                {
                    parts.Add(component.WholeComponent);
                }
                return string.Join(separator, parts.ToArray());
            }
            public DistinguishedName GetParent()
            {
                if(components.Count == 1)
                {
                    return null;
                }
                List<DNComponent> tempList = new List<DNComponent>(components);
                tempList.RemoveAt(0);
                return new DistinguishedName(tempList);
            }
            public override bool Equals(object obj)
            {
                if(obj is DistinguishedName)
                {
                    DistinguishedName objDN = (DistinguishedName)obj;
                    if (this.Components.Length == objDN.Components.Length)
                    {
                        for (int i = 0; i < this.Components.Length; i++)
                        {
                            if (!this.Components[i].Equals(objDN.Components[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                }
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return cachedDN.GetHashCode();
            }
        }
    }
