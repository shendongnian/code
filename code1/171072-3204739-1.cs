            [Serializable]
        public class ValueAndIsFile {
                [XmlAttribute]
                public bool IsFile {get; set;}
    
                [XmlAttribute]
                public string Value { get; set; }
         }
            
            ...
            
            TreeNode nd =  new TreeNode ();
            ValueAndIsFile val = new ValueAndIsFile(){ IsFile = true, Value = yourValueObject};
           
            nd.Value =SerializeToString(val);
            treeView.Nodes.Add(nd);
            
            ....
            
            protected void treeview_Navigation_SelectedNodeChanged(object sender, EventArgs e)
            {
                TreeNode node = treeview_Navigation.SelectedNode;
                ValueAndIsFile val = DeserializeFromString<ValueAndIsFile>(node.Value);            
                Response.Write(val.IsFile.ToString());
           
        }
    
    
         public static string SerializeToString(object obj)
          {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            
           using (StringWriter writer = new StringWriter())
           {
            serializer.Serialize(writer, obj);
            return writer.ToString();
           }
        }
    
        public static T DeserializeFromString<T>(string  str)
          {
            XmlSerializer serializer = new XmlSerializer(typeof(T) );
     
             using (StringReader reader =new StringReader(str) )
             {
                 return (T)serializer.Deserialize(reader);          
             }
        }
