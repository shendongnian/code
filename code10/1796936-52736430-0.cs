    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("FederalTaxIdentifier", typeof(string));
                dt.Columns.Add("ProviderName", typeof(string));
                dt.Columns.Add("ContractualRelationshipCode", typeof(string));
                dt.Columns.Add("SiteIdentifier", typeof(string));
                dt.Columns.Add("SiteName", typeof(string));
                dt.Columns.Add("LicenseTypeCode", typeof(string));
                dt.Columns.Add("OpenDate", typeof(string));
                dt.Columns.Add("CloseDate", typeof(string));
                dt.Columns.Add("DirectorPrefixName", typeof(string));
                dt.Columns.Add("DirectorFirstName", typeof(string));
                dt.Columns.Add("DirectorMiddleInitial", typeof(string));
                dt.Columns.Add("DirectorLastName", typeof(string));
                dt.Columns.Add("DirectorPhoneNumber", typeof(string));
                dt.Rows.Add(new object[] { "123", "alpha", "100", "1000", "abc", "code1","1/1/2000", "2/1/2000", "Mr.", "John", "L", "Smith", "800-555-1234"});
                dt.Rows.Add(new object[] { "123", "alpha", "100", "1001", "abc", "code1", "1/1/2000", "2/1/2000", "Mrs.", "Mary", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "123", "alpha", "100", "1001", "abc", "code1", "1/1/2000", "2/1/2000", "Mr.", "Harry", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "456", "beta", "100", "2000", "abc", "code1", "1/1/2000", "2/1/2000", "Mr.", "John", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "456", "beta", "100", "2001", "abc", "code1", "1/1/2001", "2/1/2001", "Mr.", "Ralph", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "456", "beta", "100", "2002", "abc", "code1", "1/1/2000", "2/1/2000", "Mr.", "Brutus", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "789", "gama", "100", "3000", "abc", "code1", "1/1/2000", "2/1/2000", "Mrs.", "Ronda", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "789", "gama", "100", "3001", "abc", "code1", "2/1/2000", "3/1/2000", "Mr.", "George", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "789", "gama", "100", "3002", "abc", "code1", "3/1/2000", "4/1/2000", "Mrs.", "Linda", "L", "Smith", "800-555-1234" });
                dt.Rows.Add(new object[] { "789", "gama", "100", "3003", "abc", "code1", "4/1/2000", "5/1/2000", "Mrs.", "Sally", "L", "Smith", "800-555-1234" });
                var dict = 
                    dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("FederalTaxIdentifier"), y => y)
                              .ToDictionary(x => x.Key, y => y
                                  .GroupBy(a => a.Field<string>("SiteIdentifier"), b => b)
                                  .ToDictionary( a => a.Key, b => b.FirstOrDefault()));
                               
                Providers providers = new Providers();
                providers.Provider = dict.Select(provider => new ProvidersProvider()
                {
                    FederalTaxIdentifier = provider.Key,
                    ProviderName = provider.Value.FirstOrDefault().Value.Field<string>("ProviderName"),
                    ContractualRelationshipCode = provider.Value.FirstOrDefault().Value.Field<string>("ContractualRelationshipCode"),
                    ProviderSites = provider.Value.Select(site => new ProvidersProviderProviderSite()
                    {
                        SiteIdentifier = site.Key,
                        SiteName = site.Value.Field<string>("SiteName"),
                        LicenseTypeCode = site.Value.Field<string>("LicenseTypeCode"),
                        OpenDate = site.Value.Field<string>("OpenDate"),
                        CloseDate = site.Value.Field<string>("CloseDate"),
                        DirectorPrefixName = site.Value.Field<string>("DirectorPrefixName"),
                        DirectorFirstName = site.Value.Field<string>("DirectorFirstName"),
                        DirectorMiddleInitial = site.Value.Field<string>("DirectorMiddleInitial"),
                        DirectorLastName = site.Value.Field<string>("DirectorLastName"),
                        DirectorPhoneNumber = site.Value.Field<string>("DirectorPhoneNumber")
                    }).ToArray()
                }).ToArray();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Providers));
                serializer.Serialize(writer,providers);
            }
        }
        //------------------------------------------------------------------------------
        // <auto-generated>
        //     This code was generated by a tool.
        //     Runtime Version:2.0.50727.6421
        //
        //     Changes to this file may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------
        // 
        // This source code was auto-generated by xsd, Version=2.0.50727.3038.
        // 
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
        public partial class Providers {
        
            private ProvidersProvider[] providerField;
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Provider", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public ProvidersProvider[] Provider {
                get {
                    return this.providerField;
                }
                set {
                    this.providerField = value;
                }
            }
        }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        public partial class ProvidersProvider {
        
            private string federalTaxIdentifierField;
        
            private string providerNameField;
        
            private string contractualRelationshipCodeField;
        
            private ProvidersProviderProviderSite[] providerSitesField;
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string FederalTaxIdentifier {
                get {
                    return this.federalTaxIdentifierField;
                }
                set {
                    this.federalTaxIdentifierField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ProviderName {
                get {
                    return this.providerNameField;
                }
                set {
                    this.providerNameField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ContractualRelationshipCode {
                get {
                    return this.contractualRelationshipCodeField;
                }
                set {
                    this.contractualRelationshipCodeField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("ProviderSite", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
            public ProvidersProviderProviderSite[] ProviderSites {
                get {
                    return this.providerSitesField;
                }
                set {
                    this.providerSitesField = value;
                }
            }
        }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        public partial class ProvidersProviderProviderSite {
        
            private string siteIdentifierField;
        
            private string siteNameField;
        
            private string licenseTypeCodeField;
        
            private string openDateField;
        
            private string closeDateField;
        
            private string directorPrefixNameField;
        
            private string directorFirstNameField;
        
            private string directorMiddleInitialField;
        
            private string directorLastNameField;
        
            private string directorPhoneNumberField;
        
            private string nationalProviderIdentifierField;
        
            private string webAddressField;
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string SiteIdentifier {
                get {
                    return this.siteIdentifierField;
                }
                set {
                    this.siteIdentifierField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string SiteName {
                get {
                    return this.siteNameField;
                }
                set {
                    this.siteNameField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string LicenseTypeCode {
                get {
                    return this.licenseTypeCodeField;
                }
                set {
                    this.licenseTypeCodeField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string OpenDate {
                get {
                    return this.openDateField;
                }
                set {
                    this.openDateField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string CloseDate {
                get {
                    return this.closeDateField;
                }
                set {
                    this.closeDateField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DirectorPrefixName {
                get {
                    return this.directorPrefixNameField;
                }
                set {
                    this.directorPrefixNameField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DirectorFirstName {
                get {
                    return this.directorFirstNameField;
                }
                set {
                    this.directorFirstNameField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DirectorMiddleInitial {
                get {
                    return this.directorMiddleInitialField;
                }
                set {
                    this.directorMiddleInitialField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DirectorLastName {
                get {
                    return this.directorLastNameField;
                }
                set {
                    this.directorLastNameField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DirectorPhoneNumber {
                get {
                    return this.directorPhoneNumberField;
                }
                set {
                    this.directorPhoneNumberField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string NationalProviderIdentifier {
                get {
                    return this.nationalProviderIdentifierField;
                }
                set {
                    this.nationalProviderIdentifierField = value;
                }
            }
        
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string WebAddress {
                get {
                    return this.webAddressField;
                }
                set {
                    this.webAddressField = value;
                }
            }
        }
    }
