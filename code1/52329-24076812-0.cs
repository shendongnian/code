    protected object convert(XmlNode root){
        Hashtable obj = new Hashtable();
        for(int i=0,n=root.ChildNodes.Count;i<n;i++){
            object result = null;
            XmlNode current = root.ChildNodes.Item(i);
        
            if(current.NodeType != XmlNodeType.Text)
                result = convert(current);
            else{
                int resultInt;
                double resultFloat;
                bool resultBoolean;
                if(Int32.TryParse(current.Value, out resultInt)) return resultInt;
                if(Double.TryParse(current.Value, out resultFloat)) return resultFloat;
                if(Boolean.TryParse(current.Value, out resultBoolean)) return resultBoolean;
                return current.Value;
            }
        
            if(obj[current.Name] == null)
                obj[current.Name] = result;
            else if(obj[current.Name].GetType().Equals(typeof(ArrayList)))
                ((ArrayList)obj[current.Name]).Add(result);
            else{
                ArrayList collision = new ArrayList();
                collision.Add(obj[current.Name]);
                collision.Add(result);
                obj[current.Name] = collision;
            }
        }
        
        return obj;
    }
