    public class ReportBase<TEntity> {
        public virtual void SetParameter<T>(string ParameterName, T Value) {
            throw new NotImplementedException("This report does not accept parameters.");
        }
        
        public abstract TEntity GetData();
        
        public XElement GetXmlData() {
          // calls GetData() and uses some kind of reflection to turn the data into XML?
        }
    }
