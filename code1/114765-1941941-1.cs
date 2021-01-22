    public class UserDB 
    {
        // actual data to be preserved for each user
        public int A; 
        public string Z; 
        // metadata        
        public DateTime LastSaved;
        public int eon;
        private string dbpath; 
 
        public static UserDB Load(string path)
        {
            UserDB udb;
            try
            {
                System.Xml.Serialization.XmlSerializer s=new System.Xml.Serialization.XmlSerializer(typeof(UserDB));
                using(System.IO.StreamReader reader= System.IO.File.OpenText(path))
                {
                    udb= (UserDB) s.Deserialize(reader);
                }
            }
            catch
            {
                udb= new UserDB();
            }
            udb.dbpath= path; 
            return udb;
        }
        public void Save()
        {
            LastSaved= System.DateTime.Now;
            eon++;
            var s= new System.Xml.Serialization.XmlSerializer(typeof(UserDB));
            var ns= new System.Xml.Serialization.XmlSerializerNamespaces();
            ns.Add( "", "");
            System.IO.StreamWriter writer= System.IO.File.CreateText(dbpath);
            s.Serialize(writer, this, ns);
            writer.Close();
        }
    }
