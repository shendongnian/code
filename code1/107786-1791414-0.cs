    interface IBasicProps {
       int GetPriority();
       string GetName();
       //... whatever
    }
    
    interface IBasicPropsWriteable:IBasicProps  {
       void SetPriority(int priority);
       void SetName(string name);
       //... whatever
    }
