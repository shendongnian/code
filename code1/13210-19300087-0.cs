    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.IO;
    
    namespace FWFWLib {
        public abstract class ContainerDoc : XmlDocument {
    
            protected XmlElement root = null;
            protected const string XPATH_BASE = "/$DATA_TYPE$";
            protected const string XPATH_SINGLE_FIELD = "/$DATA_TYPE$/$FIELD_NAME$";
    
            protected const string DOC_DATE_FORMAT = "yyyyMMdd";
            protected const string DOC_TIME_FORMAT = "HHmmssfff";
            protected const string DOC_DATE_TIME_FORMAT = DOC_DATE_FORMAT + DOC_TIME_FORMAT;
    
            protected readonly string datatypeName = "containerDoc";
            protected readonly string execid = System.Guid.NewGuid().ToString().Replace( "-", "" );
    
            #region startup and teardown
            public ContainerDoc( string execid, string datatypeName ) {
                root = this.DocumentElement;
                this.datatypeName = datatypeName;
                this.execid = execid;
                if( null == datatypeName || "" == datatypeName.Trim() ) {
                    throw new InvalidDataException( "Data type name can not be blank" );
                }
                Init();
            }
    
            public ContainerDoc( string datatypeName ) {
                root = this.DocumentElement;
                this.datatypeName = datatypeName;
                if( null == datatypeName || "" == datatypeName.Trim() ) {
                    throw new InvalidDataException( "Data type name can not be blank" );
                }
                Init();
            }
    
            private ContainerDoc() { /*...*/ }
    
            protected virtual void Init() {
                string basexpath = XPATH_BASE.Replace( "$DATA_TYPE$", datatypeName );
                root = (XmlElement)this.SelectSingleNode( basexpath );
                if( null == root ) {
                    root = this.CreateElement( datatypeName );
                    this.AppendChild( root );
                }
                SetFieldValue( "createdate", DateTime.Now.ToString( DOC_DATE_FORMAT ) );
                SetFieldValue( "createtime", DateTime.Now.ToString( DOC_TIME_FORMAT ) );
            }
            #endregion
    
            #region setting/getting data fields
            public virtual void SetFieldValue( string fieldname, object val ) {
                if( null == fieldname || "" == fieldname.Trim() ) {
                    return;
                }
                fieldname = fieldname.Replace( " ", "_" ).ToLower();
                string xpath = XPATH_SINGLE_FIELD.Replace( "$FIELD_NAME$", fieldname ).Replace( "$DATA_TYPE$", datatypeName );
                XmlNode node = this.SelectSingleNode( xpath );
                if( null != node ) {
                    if( null != val ) {
                        node.InnerText = val.ToString();
                    }
                } else {
                    node = this.CreateElement( fieldname );
                    if( null != val ) {
                        node.InnerText = val.ToString();
                    }
                    root.AppendChild( node );
                }
            }
    
            public virtual string FieldValue( string fieldname ) {
                if( null == fieldname ) {
                    fieldname = "";
                }
                fieldname = fieldname.ToLower().Trim();
                string rtn = "";
                XmlNode node = this.SelectSingleNode( XPATH_SINGLE_FIELD.Replace( "$FIELD_NAME$", fieldname ).Replace( "$DATA_TYPE$", datatypeName ) );
                if( null != node ) {
                    rtn = node.InnerText;
                }
                return rtn.Trim();
            }
    
            public virtual string ToXml() {
                return this.OuterXml;
            }
    
            public override string ToString() {
                return ToXml();
            }
            #endregion
    
            #region io
            public void WriteTo( string filename ) {
                TextWriter tw = new StreamWriter( filename );
                tw.WriteLine( this.OuterXml );
                tw.Close();
                tw.Dispose();
            }
    
            public void WriteTo( Stream strm ) {
                TextWriter tw = new StreamWriter( strm );
                tw.WriteLine( this.OuterXml );
                tw.Close();
                tw.Dispose();
            }
    
            public void WriteTo( TextWriter writer ) {
                writer.WriteLine( this.OuterXml );
            }
            #endregion
    
        }
    }
