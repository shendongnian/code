        public void Save(string property1)
        {
            dynamic   obj ;
            obj= Activator.CreateInstance(Type.GetType((m_Dictionary[property1])));
           
            MessageBox.Show(obj.GetType().ToString());
        }
