    public  class MyXMLSerializer
    {
        delegate void del_xmlSerializing();
        del_xmlSerializing ds;       
        
        delegate void del_xmlSerialized(System.IO.Stream stream, object o);
        AsyncCallback cb;
        del_xmlSerialized dd;
        delegate void del_xmlDeserializing();
        del_xmlDeserializing dx;       
        
        delegate object del_xmlDeserialized(System.IO.Stream stream);
        AsyncCallback db;
        del_xmlDeserialized xd;
        object FinalDeserializedObject = null;
        
        public MyXMLSerializer()
        {           
        }
        public void Serialize(System.IO.Stream stream,object o,Type ClassType)
        {
            XmlSerializer xx = new XmlSerializer(ClassType);
            /* ON Serialization Beginning [ONSERIALIZING] */
            ds = new del_xmlSerializing(OnXMLSerializing_Begin);
            IAsyncResult IAR_Begin = ds.BeginInvoke(null, null);
            ds.EndInvoke(IAR_Begin);
            /* ON Serialization Beginning [ONSERIALIZING] */
            
            /* ON Serialization Completed ie [ONSERIALIZED] */
            dd = new del_xmlSerialized(xx.Serialize);
            cb = new AsyncCallback(OnXMLSerializing_Completed);
            IAsyncResult IAR = dd.BeginInvoke(stream, o, cb, dd);
            // This Delay Is Important Otherwise The Next Line Of Code(From Where Serialize Is Called)
            // Gets Executed Prior To Conclusion Of EndInvoke, Consequently Throwing Exception.
            while (IAR.IsCompleted == false) Thread.Sleep(1);
            /* ON Serialization Completed ie [ONSERIALIZED] */            
        }
        public object Deserialize(System.IO.Stream stream,Type ClassType)
        {
            XmlSerializer xx = new XmlSerializer(ClassType);
            /* ON De-Serialization  Beginning [ONDESERIALIZING] */
            dx = new del_xmlDeserializing(OnXMLDeserializing_Begin);
            IAsyncResult IAR_Begin = dx.BeginInvoke(null, null);
            dx.EndInvoke(IAR_Begin);
            /* ON De-Serialization  Beginning [ONDESERIALIZING] */
            /* ON De-Serialization  Completed [ONDESERIALIZED] */
            xd = new del_xmlDeserialized(xx.Deserialize);
            db = new AsyncCallback(OnXMLDeserialization_Completed);
            IAsyncResult IAR = xd.BeginInvoke(stream, db, xd);                
            // This Delay Is Important Otherwise The Next Line Of Code(From Where Serialize Is Called)
            // Gets Executed Prior To Conclusion Of EndInvoke ,Consequently Throwing Exception.
            while (IAR.IsCompleted == false) Thread.Sleep(1);
            return FinalDeserializedObject;
            /* ON De-Serialization  Completed [ONDESERIALIZED] */           
        }
        
        private void OnXMLDeserialization_Completed(IAsyncResult I)
        {
            del_xmlDeserialized Clone = (del_xmlDeserialized)I.AsyncState;
            FinalDeserializedObject = Clone.EndInvoke(I);
            OnDeserialized();            
        }
        public virtual void OnSerialized()
        {
            MessageBox.Show("Serialization Completed");
        }
        public virtual void OnDeserialized()
        {
            MessageBox.Show("Deserialization Completed");
        }
        private void OnXMLSerializing_Completed(IAsyncResult I)
        {
            del_xmlSerialized Clone = (del_xmlSerialized)I.AsyncState;
            Clone.EndInvoke(I);
            OnSerialized();           
        }
        private void OnXMLDeserializing_Begin()
        {
            //Thread.Sleep(5000);
            OnDeserializing();
        }
        public virtual void OnDeserializing()
        {
            MessageBox.Show("Beginning Deserialization");
        }
        private void OnXMLSerializing_Begin()
        {
            //Thread.Sleep(5000);
            OnSerializing();
        }
        public virtual void OnSerializing()
        {
            MessageBox.Show("Beginning Serialization");
        }        
    }
