    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Dapper.SqlMapper;
    
    namespace MyNamespace.DomainDataLayer
    {    
        public class MyCustomObjectDomainData : IMyCustomObjectDomainData
        {
    
            public MyCustomObjectDomainData(IMyCustomObjectData crgDataLayer)
            {
                this.MyCustomObjectData = crgDataLayer ?? throw new ArgumentNullException("IMyCustomObjectData is null");
            }
    
            public async Task<ICollection<MyCustomObject>> MyCustomObjectGetMethodAsync()
            {
                ICollection<MyCustomObject> returnCollection = null;
                /* CALL the datalayer, but INJECT the method to handle the GridReader */
                returnCollection = await this.MyCustomObjectData.MyMethodAsync(this.HandleMyCustomObjectGridReaderResult);
                return returnCollection;
            }
    
            public ICollection<MyCustomObject> HandleMyCustomObjectGridReaderResult(GridReader gr)
            {
                ICollection<MyCustomObject> returnCollection = null;
    
                using (gr)
                {
                    /*  Get objects from each SELECT statement in the stored procedure */
                    returnCollection = gr.Read<MyCustomObject>().ToList();
    
                    /* this would be how to handle a SECOND "select" statement in the stored procedure */
                    IEnumerable<MyOtherCustomObjectFromASecondStoredProcedureSelectStatement> otherThings = gr.Read<MyOtherCustomObjectFromASecondStoredProcedureSelectStatement>().ToList();
    
                    /* optionally, you can hand-map the pocos to each other */
                    //returnCollection = new MyCustomObjectObjectMapper().MapMultipleMyCustomObject(returnCollection, otherThings);
                }
    
                return returnCollection;
            }
        }
    }
