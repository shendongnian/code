        public override void OnSerialized()
        {
            MessageBox.Show("Yippeeee!!!!!,I Finally Managed To Wire [ONSERIALIZED] Event With XMLSerializer.My Code Upon XML Serialized[ONSERIALIZED] Goes Here..");            
            //base.OnSerialized();
        }
        public override void OnSerializing()
        {
            MessageBox.Show("Yippeeee!!!!!,I Finally Managed To Wire [ONSERIALIZING] Event With XMLSerializer.My Code Upon XML Serializing[ONSERIALIZING] Goes Here..");                        
            //base.OnSerializing();
        }
        public override void OnDeserializing()
        {
            MessageBox.Show("Yes!!!!!,I Finally Managed To Wire [ONDESERIALIZING] Event With XMLSerializer.My Code Upon XML De-Serializing[ONDESERIALIZING]  Goes Here..");            
            //base.OnDeserializing();
        }
        
        public override void OnDeserialized()
        {
            MessageBox.Show("Yes!!!!!,I Finally Managed To Wire [ONDESERIALIZED] Event With XMLSerializer.My Code Upon XML De-Serialized[ONDESERIALIZED]  Goes Here..");
            //base.OnDeserialized();
        }
    }
